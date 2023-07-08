using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public record MaintainerModeState
{
    public List<MaintainerDto>? MaintainerDtos { get; init; }
    public int MaintainerModeId { get; init; }

}