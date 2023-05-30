using FlightSchoolCm.UI;
using FlightSchoolCm.UI.Interfaces;
using FlightSchoolCm.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Host and port where the API is hosted
var apiBaseAddress = "https://localhost:7015";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
builder.Services.AddScoped<IMaintainersApiClient, MaintainersApiClient>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
