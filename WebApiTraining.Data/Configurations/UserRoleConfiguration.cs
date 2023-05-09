using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApiTraining.Data.Configurations;

internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "60036f2e-61a7-4b91-927d-b433e1143d0c",
                UserId = "4d832879-2aa4-43dd-a85e-897334591cc1"
            },
            new IdentityUserRole<string>
            {
                RoleId = "7fe60b48-3fcf-4498-a031-ac2e681a424b",
                UserId = "6b25a9d8-cfff-48dd-9e66-5d4ad6c5c569"
            }
        );
    }
}
