using System.ComponentModel;
using System.Net.Http.Json;

namespace FlightSchoolTss.UI.Services;

public class MaintainersApiClient
{
    private readonly HttpClient _httpClient;

    public MaintainersApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MaintainerVm>?> GetMaintainersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/maintainer");

            if (response.IsSuccessStatusCode)
            {
                var maintainers = await response.Content.ReadFromJsonAsync<List<MaintainerVm>>();
                return maintainers;
            }
        }
        catch (Exception)
        {

            throw;
        }
        return new List<MaintainerVm>();
    }
}
public class MaintainerVm
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
