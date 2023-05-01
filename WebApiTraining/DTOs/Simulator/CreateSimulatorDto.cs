namespace WebApiTraining.DTOs.Simulator;

public class CreateSimulatorDto
{
    public string Name { get; set; }
    public string Alias { get; set; }
    public int PlatformId { get; set; }
    public bool IsActive { get; set; }
}