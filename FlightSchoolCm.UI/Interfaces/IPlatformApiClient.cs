using FlightSchoolTss.Data.DTOs.Lot;
using FlightSchoolTss.Data.DTOs.ManModule;
using FlightSchoolTss.Data.DTOs.Platform;
using FlightSchoolTss.Data.DTOs.Simulator;

namespace FlightSchoolCm.UI.Interfaces;

public interface IPlatformApiClient
{
    Task<IEnumerable<PlatformDetailsDto>> GetPlatformDetailsAsync();
    Task<IEnumerable<LotDto>> GetLotDtosAsync();
    Task<IEnumerable<ManModuleDto>> GetManModulesByLotIdAsync(int id);
    Task<IEnumerable<PlatformDto>> GetPlatformDtosByMaintainerIdAsync(int id);
    Task<IEnumerable<SimulatorDto>> GetSimulatorDtosByPlatformIdAsync(int id);
    Task<IEnumerable<SimulatorDto>> GetSimulatorDtosAsync();

}
