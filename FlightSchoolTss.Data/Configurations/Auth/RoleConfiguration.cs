using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightSchoolTss.Data.Configurations.Auth;
internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "60036f2e-61a7-4b91-927d-b433e1143d0c",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "7fe60b48-3fcf-4498-a031-ac2e681a424b",
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }
}