using Microsoft.EntityFrameworkCore;
using WebApiTraining.Configurations;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.Data.Repositories;
using WebApiTraining.Endpoints;

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

#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<ILotRepository, LotRepository>();
builder.Services.AddScoped<IMaintainerRepository, MaintainerRepository>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<ISimulatorRepository, SimulatorRepository>();

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

app.Run();