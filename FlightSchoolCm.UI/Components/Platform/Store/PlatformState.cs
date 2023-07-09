using FlightSchoolTss.Data.DTOs.Platform;

namespace FlightSchoolCm.UI.Components.Platform.Store;

public record PlatformState
{
    public List<PlatformDto>? PlatformDtos { get; init; } = new List<PlatformDto>();
    public PlatformDto? PlatformDto { get; init; } = new PlatformDto();
    public string ButtonText { get; init; } = "ADD";
    public int MaintainerId { get; set; } = 0;
}
