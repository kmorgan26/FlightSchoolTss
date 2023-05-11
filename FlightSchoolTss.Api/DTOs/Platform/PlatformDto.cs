using FlightSchoolTss.DTOs.Maintainer;

namespace FlightSchoolTss.DTOs.Platform;
public class PlatformDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
    public int MaintainerId { get; set; }

    public virtual MaintainerDto Maintainer { get; set; } = null!;
}