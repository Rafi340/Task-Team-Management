using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Domain.Entities;
using TTMS.Infrastructure.Identity;
using TTMS.Infrastructure.Seeds;

namespace TTMS.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim,
        ApplicationUserToken>
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;
        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _migrationAssembly = migrationAssembly;
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, (x) => x.MigrationsAssembly(_migrationAssembly));
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>()
                .HasMany(x => x.Tasks)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId);

            builder.Entity<ApplicationRole>().HasData(RoleSeed.GetRoles());

            builder.Entity<ApplicationUser>().HasData(UserSeed.GetUsers());

            builder.Entity<ApplicationUserRole>().HasData(UserRoleSeed.GetUserRoles());
            base.OnModelCreating(builder);
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

    }
}
