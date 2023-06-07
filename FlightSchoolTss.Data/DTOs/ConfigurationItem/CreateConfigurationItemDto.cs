namespace FlightSchoolTss.Data.DTOs.ConfigurationItem;

public class CreateConfigurationItemDto
{
    public string Name { get; set; } = null!;
    public int ItemTypeId { get; set; }
}
