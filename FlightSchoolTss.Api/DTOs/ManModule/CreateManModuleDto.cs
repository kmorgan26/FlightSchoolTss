namespace FlightSchoolTss.DTOs.ManModule;
public class CreateManModuleDto
{
    public string Name { get; set; } = null!;
    public int LotId { get; set; }
    public int MaintainableId { get; set; }

}