namespace FlightSchoolTss.Api.DTOs.SoftwareVersion;

public class CreateSoftwareVersionDto
{
    public string Name { get; set; } = null!;
    public DateTime VersionDate { get; set; }
    public int SoftwareSystemId { get; set; }
}
