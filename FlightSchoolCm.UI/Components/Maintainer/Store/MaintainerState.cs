using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolCm.UI.Components.Maintainer.Store;

public record MaintainerState
{
    public IEnumerable<MaintainerDto>? MaintainerDtos { get; init; } = new List<MaintainerDto>();

    public MaintainerDto? MaintainerDto { get; init; } = new MaintainerDto();

    public string ButtonText { get; init; } = "ADD";

    public string Message { get; init; } = string.Empty;
}