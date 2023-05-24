namespace FlightSchoolTss.Api.DTOs.HardwareVersion;

public class CreateHardwareVersionDto
{
    public string Name { get; set; } = null!;
    public DateTime VersionDate { get; set; }
    public int HardwareSystemId { get; set; }
}
