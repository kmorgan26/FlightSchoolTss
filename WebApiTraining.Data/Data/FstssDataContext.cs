using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Entities;

namespace WebApiTraining.Data.Data
{
    public class FstssDataContext : DbContext
    {
        public FstssDataContext(DbContextOptions<FstssDataContext> options) : base(options)
        {
        }
        public DbSet<Maintainer> Maintainers { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Simulator> Simulators { get; set; }
    }
}