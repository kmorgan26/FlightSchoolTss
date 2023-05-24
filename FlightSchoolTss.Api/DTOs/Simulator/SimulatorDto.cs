namespace FlightSchoolTss.DTOs.Simulator;
public class SimulatorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public int PlatformId { get; set; }
    public int MaintainableId { get; set; }
    public bool IsActive { get; set; }
}