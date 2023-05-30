using FlightSchoolCm.UI.ViewModels.Maintainer;

namespace FlightSchoolCm.UI.Interfaces;
public interface IMaintainersApiClient
{
    Task<List<MaintainerVm>?> GetMaintainersAsync();
    Task CreateMaintainerAsync(AddMaintainerVm maintainerVm);
}