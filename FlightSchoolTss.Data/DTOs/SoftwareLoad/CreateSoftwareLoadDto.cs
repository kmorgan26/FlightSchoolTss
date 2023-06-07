namespace FlightSchoolTss.Data.DTOs.SoftwareLoad;

public class CreateSoftwareLoadDto
{
    public string Name { get; set; } = null!;
    public int ConfigurationItemId { get; set; }
}
