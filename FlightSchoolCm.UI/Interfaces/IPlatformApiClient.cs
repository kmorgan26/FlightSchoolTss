using FlightSchoolTss.Data.DTOs.Platform;
using FlightSchoolTss.Data.DTOs.Simulator;

namespace FlightSchoolCm.UI.Interfaces;

public interface IPlatformApiClient
{
    Task<List<PlatformDetailsDto>> GetPlatformDetailsAsync();
    Task<IEnumerable<PlatformDto>> GetPlatformDtosByMaintainerIdAsync(int id);
    Task<List<SimulatorDto>> GetSimulatorDtosAsync();
}
