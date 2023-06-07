namespace FlightSchoolTss.Data.DTOs.SoftwareVersion;

public class SoftwareVersionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime VersionDate { get; set; }
    public int SoftwareSystemId { get; set; }
}
