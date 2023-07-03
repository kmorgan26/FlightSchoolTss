using FlightSchoolCm.UI.Interfaces;
using FlightSchoolTss.Data.DTOs.SoftwareSystem;
using Newtonsoft.Json;

namespace FlightSchoolCm.UI.Services;

public class SoftwareApiClient : ISoftwareApiClient
{
    private readonly HttpClient _httpClient;

    public SoftwareApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<SoftwareSystemDto>> GetSoftwareSystemDtoByMaintainableIdAsync(int id)
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
}
