using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FlightSchoolTss.Data.Configurations;
using FlightSchoolTss.Data.Entities.Auth;

namespace FlightSchoolTss.Data.Data
{
    public class FstssIdentityContext : IdentityDbContext<FstssUser>
    {
        private readonly IConfiguration _config;
        public FstssIdentityContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new FstssUserConfiguration(_config));
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}