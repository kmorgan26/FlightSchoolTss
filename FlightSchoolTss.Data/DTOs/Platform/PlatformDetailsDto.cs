using FlightSchoolTss.Data.DTOs.Maintainer;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.DTOs.Lot;
using FlightSchoolTss.Data.DTOs.Simulator;

namespace FlightSchoolTss.Data.DTOs.Platform;
public class PlatformDetailsDto : PlatformDto
{
    public List<SimulatorDto>? Simulators { get; set; }
    public MaintainerDto Maintainer { get; set; } = null!;
    public List<LotDto>? Lots { get; set; }
}