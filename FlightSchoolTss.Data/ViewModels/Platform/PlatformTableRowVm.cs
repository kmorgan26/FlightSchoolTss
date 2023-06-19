namespace FlightSchoolTss.Data.ViewModels.Platform;
public class PlatformTableRowVm
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Maintainer { get; set; } = null!;
    public int MaintainerId { get; set; }
}
