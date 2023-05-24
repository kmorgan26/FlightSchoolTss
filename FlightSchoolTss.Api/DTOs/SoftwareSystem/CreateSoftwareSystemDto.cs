namespace FlightSchoolTss.Api.DTOs.SoftwareSystem;

public class CreateSoftwareSystemDto
{
    public string Name { get; set; } = null!;
    public int MaintainableId { get; set; }
}
