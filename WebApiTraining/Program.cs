using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
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



app.Run();