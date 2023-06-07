using FlightSchoolTss.Data.ViewModels.Maintainer;
using FlightSchoolTss.DTOs.Maintainer;

namespace FlightSchoolCm.UI.Interfaces;
public interface IMaintainersApiClient
{
    Task<List<MaintainerVm>?> GetMaintainersAsync();
    Task<MaintainerVm> GetMaintainerVmByIdAsync(int id);
    Task CreateMaintainerAsync(CreateMaintainerDto dto);
    Task<int> UpdateMaintainerAsync(MaintainerVm maintainerVm);
}