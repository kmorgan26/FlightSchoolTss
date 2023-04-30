using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTraining.Data.Entities;

namespace WebApiTraining.Data.Configurations;
internal class SimulatorConfiguration : IEntityTypeConfiguration<Simulator>
{
    public void Configure(EntityTypeBuilder<Simulator> modelBuilder)
    {
        modelBuilder
            .HasData(
                new Simulator { Id = 1, Name = "5932", PlatformId = 2, IsActive = true },
                new Simulator { Id = 2, Name = "5933", PlatformId = 2, IsActive = true },
                new Simulator { Id = 3, Name = "5934", PlatformId = 2, IsActive = true },
                new Simulator { Id = 4, Name = "5935", PlatformId = 2, IsActive = true },
                new Simulator { Id = 5, Name = "7601", PlatformId = 3, IsActive = true },
                new Simulator { Id = 6, Name = "7602", PlatformId = 3, IsActive = true },
                new Simulator { Id = 7, Name = "5930", PlatformId = 4, IsActive = true },
                new Simulator { Id = 8, Name = "5921", PlatformId = 4, IsActive = true },
                new Simulator { Id = 9, Name = "5924", PlatformId = 4, IsActive = true },
                new Simulator { Id = 10, Name = "5925", PlatformId = 4, IsActive = true },
                new Simulator { Id = 11, Name = "5926", PlatformId = 4, IsActive = true },
                new Simulator { Id = 12, Name = "5927", PlatformId = 4, IsActive = true },
                new Simulator { Id = 13, Name = "5928", PlatformId = 4, IsActive = true },
                new Simulator { Id = 14, Name = "5937", PlatformId = 4, IsActive = true },
                new Simulator { Id = 15, Name = "5938", PlatformId = 4, IsActive = true },
                new Simulator { Id = 16, Name = "8719", PlatformId = 5, IsActive = true },
                new Simulator { Id = 17, Name = "8720", PlatformId = 5, IsActive = true },
                new Simulator { Id = 18, Name = "8721", PlatformId = 5, IsActive = true },
                new Simulator { Id = 19, Name = "8722", PlatformId = 5, IsActive = true },
                new Simulator { Id = 20, Name = "8723", PlatformId = 5, IsActive = true },
                new Simulator { Id = 21, Name = "8724", PlatformId = 5, IsActive = true },
                new Simulator { Id = 22, Name = "8725", PlatformId = 5, IsActive = true },
                new Simulator { Id = 23, Name = "8726", PlatformId = 5, IsActive = true },
                new Simulator { Id = 24, Name = "8727", PlatformId = 5, IsActive = true },
                new Simulator { Id = 25, Name = "8728", PlatformId = 5, IsActive = true },
                new Simulator { Id = 26, Name = "8729", PlatformId = 5, IsActive = true },
                new Simulator { Id = 27, Name = "8730", PlatformId = 5, IsActive = true },
                new Simulator { Id = 28, Name = "8731", PlatformId = 5, IsActive = true },
                new Simulator { Id = 29, Name = "8732", PlatformId = 5, IsActive = true },
                new Simulator { Id = 30, Name = "8733", PlatformId = 5, IsActive = true },
                new Simulator { Id = 31, Name = "8734", PlatformId = 5, IsActive = true },
                new Simulator { Id = 32, Name = "8735", PlatformId = 5, IsActive = true },
                new Simulator { Id = 33, Name = "8736", PlatformId = 5, IsActive = true },
                new Simulator { Id = 34, Name = "8737", PlatformId = 5, IsActive = true },
                new Simulator { Id = 35, Name = "8738", PlatformId = 5, IsActive = true },
                new Simulator { Id = 36, Name = "8739", PlatformId = 5, IsActive = true },
                new Simulator { Id = 37, Name = "8740", PlatformId = 5, IsActive = true },
                new Simulator { Id = 38, Name = "8745", PlatformId = 6, IsActive = true },
                new Simulator { Id = 39, Name = "8746", PlatformId = 6, IsActive = true },
                new Simulator { Id = 40, Name = "8747", PlatformId = 6, IsActive = true },
                new Simulator { Id = 41, Name = "8748", PlatformId = 6, IsActive = true },
                new Simulator { Id = 42, Name = "8749", PlatformId = 6, IsActive = true },
                new Simulator { Id = 43, Name = "8750", PlatformId = 6, IsActive = true },
                new Simulator { Id = 44, Name = "8751", PlatformId = 6, IsActive = true },
                new Simulator { Id = 45, Name = "8752", PlatformId = 6, IsActive = true },
                new Simulator { Id = 46, Name = "8753", PlatformId = 6, IsActive = true },
                new Simulator { Id = 47, Name = "8754", PlatformId = 6, IsActive = true }
            );
    }
}