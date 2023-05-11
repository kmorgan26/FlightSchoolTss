using FlightSchoolTss.DTOs.Lot;
using FlightSchoolTss.DTOs.Simulator;

namespace FlightSchoolTss.DTOs.Platform;
public class PlatformDetailsDto : PlatformDto
{
    public List<SimulatorDto>? Simulators { get; set; }
    public List<LotDto>? Lots { get; set; }
}