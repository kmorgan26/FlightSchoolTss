using FlightSchoolCm.UI.Interfaces;
using FlightSchoolTss.Data.DTOs.Lot;
using FlightSchoolTss.Data.DTOs.ManModule;
using FlightSchoolTss.Data.DTOs.Platform;
using FlightSchoolTss.Data.DTOs.Simulator;
using Newtonsoft.Json;

namespace FlightSchoolCm.UI.Services;

public class PlatformApiClient : IPlatformApiClient
{
    private readonly HttpClient _httpClient;

    public PlatformApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<LotDto>> GetLotDtosAsync()
    {
        var response = await _httpClient.GetAsync($"/api/lot/");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var platform = JsonConvert.DeserializeObject<List<LotDto>>(content);

            return platform!;
        }

        return null!;
    }

    public async Task<IEnumerable<ManModuleDto>> GetManModulesByLotIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/manmodule/GetByLotIdAsync/{id}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var simulator = JsonConvert.DeserializeObject<IEnumerable<ManModuleDto>>(content);

            return simulator!;
        }

        return null!;
    }

    public async Task<IEnumerable<PlatformDetailsDto>> GetPlatformDetailsAsync()
    {
        var response = await _httpClient.GetAsync($"/api/platform/GetPlatformDetailDtos");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            
            var platform = JsonConvert.DeserializeObject<IEnumerable<PlatformDetailsDto>>(content);

            return platform!;
        }

        return null!;
    }

    public async Task<IEnumerable<PlatformDto>> GetPlatformDtosByMaintainerIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/platform/GetByMaintainerId/{id}");

        if(response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var platforms = JsonConvert.DeserializeObject<IEnumerable<PlatformDto>>(content);
            return platforms!;
        }
        return null!;
    }

    public async Task<IEnumerable<SimulatorDto>> GetSimulatorDtosAsync()
    {
        var response = await _httpClient.GetAsync($"/api/simulator/GetSimulatorDtos");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var simulator = JsonConvert.DeserializeObject<List<SimulatorDto>>(content);

            return simulator!;
        }

        return null!;
    }

    public async Task<IEnumerable<SimulatorDto>> GetSimulatorDtosByPlatformIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/simulator/GetByPlatformId/{id}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var simulators = JsonConvert.DeserializeObject<IEnumerable<SimulatorDto>>(content);
            return simulators!;
        }
        return null!;
    }
}
