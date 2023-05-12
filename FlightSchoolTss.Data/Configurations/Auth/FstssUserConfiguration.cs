using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using FlightSchoolTss.Data.Entities.Auth;

namespace FlightSchoolTss.Data.Configurations.Auth;
internal class FstssUserConfiguration : IEntityTypeConfiguration<FstssUser>
{
    private readonly IConfiguration _config;

    public FstssUserConfiguration(IConfiguration config)
    {
        _config = config;
    }

    public void Configure(EntityTypeBuilder<FstssUser> builder)
    {
        var hasher = new PasswordHasher<FstssUser>();
        var passwordString = _config.GetSection("UserSettings:Password").Value;

        builder.HasData(
            new FstssUser
            {
                Id = "4d832879-2aa4-43dd-a85e-897334591cc1",
                Email = "kevin.d.morgan@gdit.com",
                NormalizedEmail = "KEVIN.D.MORGAN@GDIT.COM",
                NormalizedUserName = "KEVIN.D.MORGAN@GDIT.COM",
                UserName = "kevin.d.morgan@gdit.com",
                FirstName = "Kevin",
                LastName = "Morgan",
                PasswordHash = hasher.HashPassword(null, passwordString),
                EmailConfirmed = true
            },
            new FstssUser
            {
                Id = "6b25a9d8-cfff-48dd-9e66-5d4ad6c5c569",
                Email = "kmorgan26@gmail.com",
                NormalizedEmail = "KMORGAN26@GMAIL.COM",
                NormalizedUserName = "KMORGAN26@GMAIL.COM",
                UserName = "KMORGAN26@GMAIL.COM",
                FirstName = "Kevin",
                LastName = "Morgan",
                PasswordHash = hasher.HashPassword(null, passwordString),
                EmailConfirmed = true
            }

        );
    }
}