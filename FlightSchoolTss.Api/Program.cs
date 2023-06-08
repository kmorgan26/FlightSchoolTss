using FlightSchoolTss.Configurations;
using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Entities.Auth;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Data.Repositories;
using FlightSchoolTss.DTOs.Maintainer;
using FlightSchoolTss.Endpoints;
using FlightSchoolTss.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region connection strings and contexts
//Connection Strings are stored in the json file in User Secrets on development machines

var connectionString = builder.Configuration.GetConnectionString("FstssDataConnectionString");

//builder.Services.AddDbContextPool<FstssDataContext>(i => i.UseSqlServer(connectionString));

builder.Services.AddDbContext<FstssDataContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var identityConnectionString = builder.Configuration.GetConnectionString("FstssIdentityConnectionString");

builder.Services.AddDbContext<FstssIdentityContext>(options =>
{
    options.UseSqlServer(identityConnectionString);
});

builder.Services.AddIdentityCore<FstssUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FstssIdentityContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7015";
        options.Audience = "https://localhost:7187";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
        };
    });

#endregion

builder.Services.AddAutoMapper(typeof(MapperConfig));
//builder.Services.AddAuthorization();

//lock down the entire API to Authentication===========================
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
builder.Services.AddScoped<IConfigurationItemRepository, ConfigurationItemRepository>();
builder.Services.AddScoped<IHardwareConfigurationRepository, HardwareConfigurationRepository>();
builder.Services.AddScoped<IHardwareSystemRepository, HardwareSystemRepository>();
builder.Services.AddScoped<IHardwareVersionRepository, HardwareVersionRepository>();
builder.Services.AddScoped<IHardwareVersionsConfigurationsRepository, HardwareVersionsConfigurationRepository>();
builder.Services.AddScoped<IItemTypeRepository, ItemTypeRepository>();
builder.Services.AddScoped<ILotRepository, LotRepository>();
builder.Services.AddScoped<IMaintainableRepository, MaintainableRepository>();
builder.Services.AddScoped<IMaintainerRepository, MaintainerRepository>();
builder.Services.AddScoped<IManModuleRepository, ManModuleRepository>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<ISimulatorRepository, SimulatorRepository>();
builder.Services.AddScoped<ISoftwareLoadRepository, SoftwareLoadRepository>();
builder.Services.AddScoped<ISoftwareSystemRepository, SoftwareSystemRepository>();
builder.Services.AddScoped<ISoftwareVersionsLoadsRepository, SoftwareVersionsLoadsRepository>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddValidatorsFromAssemblyContaining<MaintainerDto>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseCors("AllowAll");
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapConfigurationItemEndpoints();
app.MapConfigurationEndpoints();
app.MapHardwareConfigurationEndpoints();
app.MapHardwareSystemEndpoints();
app.MapHardwareVersionEndpoints();
app.MapHardwareVersionsConfigurationsEndpoints();
app.MapItemTypeEndpoints();
app.MapMaintainableEndpoints();
app.MapMaintainerEndpoints();
app.MapPlatformEndpoints();
app.MapSimulatorEndpoints();
app.MapLotEndpoints();
app.MapManModuleEndpoints();
app.MapAuthenticationEndpoints();
app.MapSoftwareLoadEndpoints();
app.MapSoftwareSystemEndpoints();
app.MapSoftwareVersionEndpoints();

app.Run();