﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiTraining.Configurations;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities.Auth;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.Data.Repositories;
using WebApiTraining.Endpoints;
using WebApiTraining.Services;

var builder = WebApplication.CreateBuilder(args);

#region connection strings and contexts
//Connection Strings are stored in the json file in User Secrets on development machines

var connectionString = builder.Configuration.GetConnectionString("FstssDataConnectionString");

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


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<ILotRepository, LotRepository>();
builder.Services.AddScoped<IMaintainerRepository, MaintainerRepository>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<ISimulatorRepository, SimulatorRepository>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapMaintainerEndpoints();
app.MapPlatformEndpoints();
app.MapSimulatorEndpoints();
app.MapLotEndpoints();
app.MapAuthenticationEndpoints();

app.Run();