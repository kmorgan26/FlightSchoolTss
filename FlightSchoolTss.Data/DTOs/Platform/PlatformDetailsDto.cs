using FlightSchoolTss.Data.DTOs.Maintainer;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.DTOs.Lot;
using FlightSchoolTss.DTOs.Simulator;

namespace FlightSchoolTss.DTOs.Platform;
public class PlatformDetailsDto : PlatformDto
{
    public List<SimulatorDto>? Simulators { get; set; }
    public MaintainerDto Maintainer { get; set; } = null!;
    public List<LotDto>? Lots { get; set; }
}