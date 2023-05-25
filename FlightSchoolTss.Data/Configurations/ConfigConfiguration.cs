using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlightSchoolTss.Data.Entities;

namespace FlightSchoolTss.Data.Configurations;
internal class ConfigConfiguration : IEntityTypeConfiguration<ConfigConfiguration>
{
    public void Configure(EntityTypeBuilder<ConfigConfiguration> builder)
    {
        builder
            .HasData(
                new Configuration { Id = 1, ConfigurationItemId = 1, MaintainableId = 8 },
                new Configuration { Id = 2, ConfigurationItemId = 2, MaintainableId = 8 },
                new Configuration { Id = 3, ConfigurationItemId = 3, MaintainableId = 8 }
        );
    }
}
