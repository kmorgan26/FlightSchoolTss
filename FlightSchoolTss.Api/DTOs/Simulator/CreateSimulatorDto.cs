namespace FlightSchoolTss.DTOs.Simulator;
public class CreateSimulatorDto
{
    public string Name { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public int PlatformId { get; set; }
    public bool IsActive { get; set; }
}