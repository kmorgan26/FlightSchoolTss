using FlightSchoolTss.Data.DTOs.Lot;
using FlightSchoolTss.Data.DTOs.Platform;
using FlightSchoolTss.Data.DTOs.Simulator;

namespace FlightSchoolCm.UI.Interfaces;

public interface IPlatformApiClient
{
    Task<List<PlatformDetailsDto>> GetPlatformDetailsAsync();
    Task<IEnumerable<PlatformDto>> GetPlatformDtosByMaintainerIdAsync(int id);
    Task<IEnumerable<SimulatorDto>> GetSimulatorDtosByPlatformIdAsync(int id);
    Task<IEnumerable<LotDto>> GetLotDtosAsync();
    Task<List<SimulatorDto>> GetSimulatorDtosAsync();
    Task<int> GetMaintainableIdFromPlatformId(int id);
}
