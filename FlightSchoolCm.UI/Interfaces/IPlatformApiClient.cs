using FlightSchoolTss.Data.DTOs.Platform;
using FlightSchoolTss.Data.DTOs.Simulator;

namespace FlightSchoolCm.UI.Interfaces;

public interface IPlatformApiClient
{
    Task<List<PlatformDetailsDto>> GetPlatformDetailsAsync();
    Task<List<SimulatorDto>> GetSimulatorDtosAsync();
}
