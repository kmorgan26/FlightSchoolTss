using WebApiTraining.DTOs.Lot;
using WebApiTraining.DTOs.Simulator;

namespace WebApiTraining.DTOs.Platform;
public class PlatformDetailsDto : PlatformDto
{
    public List<SimulatorDto>? Simulators { get; set; }
    public List<LotDto>? Lots { get; set; }
}