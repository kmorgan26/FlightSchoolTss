using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightSchoolTss.Data.Entities;

namespace FlightSchoolTss.Data.Configurations;
internal class MaintainerConfiguration : IEntityTypeConfiguration<Maintainer>
{
    public void Configure(EntityTypeBuilder<Maintainer> modelBuilder)
    {
        modelBuilder
            .HasData(
                new Maintainer { Id=1, Name = "Flight Safety" },
                new Maintainer { Id=2, Name = "CAE" },
                new Maintainer { Id=3, Name = "AVT" }
            );
    }
}