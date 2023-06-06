using FlightSchoolTss.Data.ViewModels.Maintainer;

namespace FlightSchoolCm.UI.Interfaces;
public interface IMaintainersApiClient
{
    Task<List<MaintainerVm>?> GetMaintainersAsync();
    Task CreateMaintainerAsync(AddMaintainerVm maintainerVm);
}