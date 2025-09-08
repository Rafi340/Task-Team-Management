using Autofac.Extensions.DependencyInjection;
using TTMS.Infrastructure.Extensions;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;
using TTMS.API;
using TTMS.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using TTMS.WebAPI.Swagger;
using TTMS.WebAPI.Endpoints;
using Asp.Versioning;
using TTMS.Application.Features.Teams.Commands;
using TTMS.WebAPI.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateBootstrapLogger();
try
{
    Log.Information("Applicaton Starting...");
    var builder = WebApplication.CreateBuilder(args);
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"]
        };
    });
    builder.Services.AddAuthorization();
    #region Automapper Configuration
    builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());
    #endregion

    builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

    builder.Services.AddSwaggerGen(x => x.OperationFilter<SwaggerDefaultValues>());

    var migrationAssembly = Assembly.GetExecutingAssembly();
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, x => x.MigrationsAssembly(migrationAssembly)));


    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    // Add services to the container.

    #region Autofac Configuration
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApiModule(connectionString, migrationAssembly?.FullName));
    });
    #endregion

    #region Serilog Configuration
    builder.Host.UseSerilog((context, lc) =>
    lc.MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
    );
    #endregion

    #region MediatR Configuration
    builder.Services.AddMediatR(cfg => {
        cfg.RegisterServicesFromAssembly(migrationAssembly);
        cfg.RegisterServicesFromAssembly(typeof(TeamAddCommand).Assembly);
    });
    #endregion

    #region ApiVersion
    builder.Services.AddApiVersioning(x =>
    {
        x.DefaultApiVersion = new ApiVersion(1.0);
        x.AssumeDefaultVersionWhenUnspecified = true;
        x.ReportApiVersions = true;
        x.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
    }).AddApiExplorer();
    #endregion

    #region Identity Configuration
    builder.Services.AddIdentity();
    #endregion

    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    var app = builder.Build();
    app.CreateApiVersionSet();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(x =>
        {
            foreach (var description in app.DescribeApiVersions())
            {
                x.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName);

            }
        });
        //app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseAuthorization();
    app.UseMiddleware<ValidationMappingMiddleware>();
    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application crashed.");
}
finally
{

}

