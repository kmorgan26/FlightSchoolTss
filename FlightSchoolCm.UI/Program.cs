using Fluxor;
using FlightSchoolCm.UI;
using FlightSchoolCm.UI.Interfaces;
using FlightSchoolCm.UI.Services;
using FlightSchoolTss.Data.Configurations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using FlightSchoolTss.DTOs.Maintainer;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(typeof(MapperConfig));

// Host and port where the API is hosted
var apiBaseAddress = "https://localhost:7015";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
builder.Services.AddScoped<IMaintainersApiClient, MaintainersApiClient>();

builder.Services.AddScoped<IGenericApiClient<MaintainerDto>>
    (c => new GenericApiClient<MaintainerDto>(apiBaseAddress, "/api/"));

builder.Services.AddMudServices();
builder.Services.AddFluxor(o => o.ScanAssemblies(typeof(Program).Assembly));

await builder.Build().RunAsync();
