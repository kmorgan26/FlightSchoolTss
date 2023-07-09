using FlightSchoolTss.Data.DTOs.Platform;

namespace FlightSchoolCm.UI.Components.Platform.Store;

public class PlatformButtonTextChangeAction
{
    public string ButtonText { get; init; } = "ADD";
}
public class PlatformDtoChangeAction
{
    public PlatformDto? PlatformDto { get; init; } = new PlatformDto();
}
public class PlatformDtosChangeAction
{
    public List<PlatformDto>? PlatformDtos { get; init; } = new List<PlatformDto>();
}
public class PlatformMaintainerIdChangeAction
{
    public int MaintainerId { get; set; } = 0;
}