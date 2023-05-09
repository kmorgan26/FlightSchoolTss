using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApiTraining.Data.Configurations;
using WebApiTraining.Data.Entities.Auth;

namespace WebApiTraining.Data.Data
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
