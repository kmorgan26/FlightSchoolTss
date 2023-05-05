using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.DTOs.Simulator;

public class SimulatorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public int PlatformId { get; set; }
    public bool IsActive { get; set; }

    public virtual PlatformDto Platform { get; set; }
}