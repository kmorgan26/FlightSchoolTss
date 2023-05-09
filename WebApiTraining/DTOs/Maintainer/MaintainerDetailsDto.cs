using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.DTOs.Maintainer;

public class MaintainerDetailsDto : MaintainerDto
{
    public virtual List<PlatformDetailsDto> Platforms { get; set; } = null!;
}