using Autofac;
using FluentValidation;
using TTMS.Application;
using TTMS.Application.Validator;
using TTMS.Domain.Repositories;
using TTMS.Infrastructure;
using TTMS.Infrastructure.Identity;
using TTMS.Infrastructure.Repositories;

namespace TTMS.API
{
    public class ApiModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;
        public ApiModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TeamRepository>().As<ITeamRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(TeamValidator).Assembly)
            .AsClosedTypesOf(typeof(IValidator<>))
            .InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
