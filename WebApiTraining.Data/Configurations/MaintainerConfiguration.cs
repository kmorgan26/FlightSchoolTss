using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTraining.Data.Entities;

namespace WebApiTraining.Data.Configurations;
internal class MaintainerConfiguration : IEntityTypeConfiguration<Maintainer>
{
    public void Configure(EntityTypeBuilder<Maintainer> modelBuilder)
    {
        modelBuilder
            .HasData(
                new Maintainer { Id=1, Name = "Flight Safety" },
                new Maintainer { Id=2, Name = "L3Harris" },
                new Maintainer { Id=3, Name = "AVT" }
            );
    }
}