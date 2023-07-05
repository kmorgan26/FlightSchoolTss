using Fluxor;
using FlightSchoolCm.UI;
using FlightSchoolCm.UI.Interfaces;
using FlightSchoolCm.UI.Services;
using FlightSchoolTss.Data.Configurations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using FlightSchoolTss.Data.DTOs.Maintainer;
using FlightSchoolTss.Data.DTOs.Platform;
using FlightSchoolTss.Data.DTOs.Maintainable;
using FlightSchoolTss.Data.DTOs.Simulator;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(typeof(MapperConfig));

// Host and port where the API is hosted
var apiBaseAddress = "https://localhost:7015";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

builder.Services.AddScoped<IGenericApiClient<MaintainerDto>>
    (c => new GenericApiClient<MaintainerDto>(apiBaseAddress, "/api/maintainer"));

builder.Services.AddScoped<IGenericApiClient<PlatformDto>>
    (c => new GenericApiClient<PlatformDto>(apiBaseAddress, "/api/platform"));

builder.Services.AddScoped<IGenericApiClient<SimulatorDto>>
    (c => new GenericApiClient<SimulatorDto>(apiBaseAddress, "/api/simulator"));


builder.Services.AddScoped<IGenericApiClient<MaintainableDto>>
    (c => new GenericApiClient<MaintainableDto>(apiBaseAddress, "/api/maintainable"));

builder.Services.AddScoped<IPlatformApiClient, PlatformApiClient>();
builder.Services.AddScoped<ISoftwareApiClient, SoftwareApiClient>();

builder.Services.AddMudServices();
builder.Services.AddFluxor(o => o.ScanAssemblies(typeof(Program).Assembly));

await builder.Build().RunAsync();
