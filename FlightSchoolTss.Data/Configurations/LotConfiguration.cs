using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightSchoolTss.Data.Entities;

namespace FlightSchoolTss.Data.Configurations;
internal class LotConfiguration : IEntityTypeConfiguration<Lot>
{
    public void Configure(EntityTypeBuilder<Lot> modelBuilder)
    {
        modelBuilder
            .HasData(
                new Lot { Id = 1, Name = "Lot 1", PlatformId = 8 },
                new Lot { Id = 2, Name = "Lot 2", PlatformId = 8 },
                new Lot { Id = 3, Name = "Lot 3", PlatformId = 8 }
            );
    }
}