using FlightSchoolTss.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightSchoolTss.Data.Configurations;
internal class ItemTypeConfiguration : IEntityTypeConfiguration<ItemType>
{
    public void Configure(EntityTypeBuilder<ItemType> builder)
    {
        builder
            .HasData(
                new ItemType { Id = 1, Name = "Software Load" },
                new ItemType { Id = 2, Name = "Hardware Config" }
            );
    }
}
