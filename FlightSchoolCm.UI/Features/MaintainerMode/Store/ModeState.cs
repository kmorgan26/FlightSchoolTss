using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public record ModeState
{
    public List<MaintainerDto>? MaintainerDtos { get; init; }
    
    public int MaintainerId { get; init; }
    public int PlatformId { get; init; }
    public int SimulatorId { get; init; }
    public int LotId { get; init; }
    public int ManModuleId { get; init; }
    public int MaintainableModeId { get; init; }

}