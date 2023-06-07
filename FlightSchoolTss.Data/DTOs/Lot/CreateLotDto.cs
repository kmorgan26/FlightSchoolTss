namespace FlightSchoolTss.DTOs.Lot;
public class CreateLotDto
{
    public string Name { get; set; } = null!;
    public int PlatformId { get; set; }
    public int MaintainableId { get; set; }
}
