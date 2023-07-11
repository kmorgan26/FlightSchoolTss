namespace FlightSchoolTss.Data.DTOs.ManModule;
public class ManModuleDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int LotId { get; set; }
    public int MaintainableId { get; set; }
}
