using FlightSchoolCm.UI.Interfaces;
using FlightSchoolTss.DTOs.Platform;
using Newtonsoft.Json;

namespace FlightSchoolCm.UI.Services;

public class PlatformApiClient : IPlatformApiClient
{
    private readonly HttpClient _httpClient;

    public PlatformApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PlatformDetailsDto>> GetPlatformDetailsAsync()
    {
        var response = await _httpClient.GetAsync($"/api/platform/GetPlatformTableRowVms");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            
            var platform = JsonConvert.DeserializeObject<List<PlatformDetailsDto>>(content);

            return platform;
        }

        return null;
    }
}
