using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.DTOs.Maintainer;

public class MaintainerDetailsDto : MaintainerDto
{
    public virtual List<PlatformDto> Platforms { get; set; } = null!;
}