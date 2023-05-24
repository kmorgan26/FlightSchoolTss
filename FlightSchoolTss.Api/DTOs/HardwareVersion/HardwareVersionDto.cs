namespace FlightSchoolTss.Api.DTOs.HardwareVersion;

public class HardwareVersionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime VersionDate { get; set; }
    public int HardwareSystemId { get; set; }

}
