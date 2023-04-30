using Microsoft.EntityFrameworkCore;
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
        }

        public DbSet<Maintainer> Maintainers { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Simulator> Simulators { get; set; }
    }
}