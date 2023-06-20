using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolTss.Data.DTOs.Platform;
public class PlatformDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
    public int MaintainerId { get; set; }
    public int MaintainableId { get; set; }
}