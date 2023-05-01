using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTraining.Data.Entities;

namespace WebApiTraining.Data.Configurations;
internal class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> modelBuilder)
    {
        modelBuilder
            .HasData(
                new Platform { Id=1, Name = "AH-64E", MaintainerId = 1, IsActive = false },
                new Platform { Id=2, Name = "CH-47F", MaintainerId = 2, IsActive = true },
                new Platform { Id=3, Name = "TH-1H", MaintainerId = 1, IsActive = true },
                new Platform { Id=4, Name = "UH-60L", MaintainerId = 2, IsActive = true },
                new Platform { Id=5, Name = "UH-60M", MaintainerId = 2, IsActive = true },
                new Platform { Id=6, Name = "UH-72A", MaintainerId = 1, IsActive = true },
                new Platform { Id=7, Name = "UH-72CPT", MaintainerId = 1, IsActive = true },
                new Platform { Id=8, Name ="RCTD", MaintainerId=2, IsActive=true }
            );
    }
}