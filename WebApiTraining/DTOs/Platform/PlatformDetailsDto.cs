using WebApiTraining.DTOs.Simulator;

namespace WebApiTraining.DTOs.Platform;
public class PlatformDetailsDto : PlatformDto
{
    public List<SimulatorDto> Simulators { get; set; } = new List<SimulatorDto>();
}