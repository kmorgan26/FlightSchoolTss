using FlightSchoolTss.Data.ViewModels.Maintainer;

namespace FlightSchoolCm.UI.Interfaces;
public interface IMaintainersApiClient
{
    Task<List<MaintainerVm>?> GetMaintainersAsync();
    Task<MaintainerVm> GetMaintainerVmByIdAsync(int id);
    Task CreateMaintainerAsync(AddMaintainerVm maintainerVm);
    Task<int> UpdateMaintainerAsync(MaintainerVm maintainerVm);
}