using FlightSchoolTss.DTOs.Platform;

namespace FlightSchoolTss.Data.DTOs.Maintainer;

public class MaintainerDetailsDto : MaintainerDto
{
    public virtual List<PlatformDetailsDto> Platforms { get; set; } = null!;
}