using FlightSchoolCm.UI.Interfaces;
using FlightSchoolTss.Data.DTOs.SoftwareSystem;
using FlightSchoolTss.Data.DTOs.SoftwareVersion;
using Newtonsoft.Json;

namespace FlightSchoolCm.UI.Services;

public class SoftwareApiClient : ISoftwareApiClient
{
    private readonly HttpClient _httpClient;

    public SoftwareApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<SoftwareSystemDto>> GetSoftwareSystemDtosByMaintainableIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/softwaresystem/GetSoftwareSystemsByMaintainableId/{id}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var dtos = JsonConvert.DeserializeObject<List<SoftwareSystemDto>>(content);

            return dtos!;
        }

        return null!;
    }

    public async Task<IEnumerable<SoftwareVersionDto>> GetSoftwareVersionDtosBySoftwareSystemIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/softwareversion/GetSoftwareVersionsBySoftwareSystemId/{id}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var dtos = JsonConvert.DeserializeObject<List<SoftwareVersionDto>>(content)
                .OrderByDescending(i => i.VersionDate);
            
            return dtos!;
        }

        return null!;
    }
}
