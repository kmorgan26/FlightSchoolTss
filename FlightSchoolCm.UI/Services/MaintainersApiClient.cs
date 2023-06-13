using System.Net.Http.Json;
using FlightSchoolCm.UI.Interfaces;
using FlightSchoolTss.Data.ViewModels.Maintainer;
using FlightSchoolTss.DTOs.Maintainer;
using FlightSchoolTss.DTOs.ManModule;
using MudBlazor;

namespace FlightSchoolCm.UI.Services;

public class MaintainersApiClient : IMaintainersApiClient
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
    public async Task<MaintainerVm> GetMaintainerVmByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/maintainer/{id}");
            if (response.IsSuccessStatusCode)
            {
                var maintainer = await response.Content.ReadFromJsonAsync<MaintainerVm>();
                return maintainer is not null ? maintainer : new MaintainerVm();
            }
        }
        catch (Exception)
        {
            throw;
        }
        return new MaintainerVm();
    }

    public async Task CreateMaintainerAsync(CreateMaintainerDto dto)
    {
        try
        {
            var content = JsonContent.Create(dto);
            await _httpClient.PostAsync("/api/maintainer", content);
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            throw;
        }
    }

    public async Task<int> UpdateMaintainerAsync(MaintainerVm maintainerVm)
    {
        try
        {
            var result = await _httpClient.PutAsync($"/api/maintainer/{maintainerVm.Id}", JsonContent.Create(maintainerVm));
            return result.IsSuccessStatusCode ? 1 : 0;
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            return 0;
            throw;
        }
    }

    public async Task<bool> DeleteMaintainerAsync(int id)
    {
        try
        {
            var result = await _httpClient.DeleteAsync($"/api/maintainer/{id}");
            return result.IsSuccessStatusCode ? true : false;
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            return false; 
        }
    }
}
