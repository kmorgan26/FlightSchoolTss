using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WebApiTraining.Data.Configurations;
using WebApiTraining.Data.Entities;

namespace WebApiTraining.Data.Data
{
    public class FstssDataContext : DbContext
    {
        public FstssDataContext(DbContextOptions<FstssDataContext> options) : base(options)
        {
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MaintainerConfiguration());
            modelBuilder.ApplyConfiguration(new PlatformConfiguration());
            modelBuilder.ApplyConfiguration(new SimulatorConfiguration());
            modelBuilder.ApplyConfiguration(new LotConfiguration());
        }

        public DbSet<Maintainer> Maintainers { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Simulator> Simulators { get; set; }
        public DbSet<Lot> Lots { get; set; }

    }
    public class FstssDataContextFactory : IDesignTimeDbContextFactory<FstssDataContext>
    {
        public FstssDataContext CreateDbContext(string[] args)
        {
            //get environment
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                .Build();

            // get conn string
            var optionsBuilder = new DbContextOptionsBuilder<FstssDataContext>();
            var connectionString = config.GetConnectionString("FstssDataConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
            return new FstssDataContext(optionsBuilder.Options);
        }
    }
}