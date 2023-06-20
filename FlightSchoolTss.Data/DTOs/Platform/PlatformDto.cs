using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolTss.Data.DTOs.Platform;
public class PlatformDto
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
    public int MaintainerId { get; set; } = 0;
    public int MaintainableId { get; set; } = 0;
}