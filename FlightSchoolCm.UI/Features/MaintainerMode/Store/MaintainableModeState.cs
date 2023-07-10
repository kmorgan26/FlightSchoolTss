using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public record MaintainableModeState
{
    public List<MaintainerDto>? MaintainerDtos { get; init; }
    
    public int MaintainerModeId { get; init; }
    public int PlatformModeId { get; init; }
    public int SimulatorModeId { get; init; }
    public int LotModeId { get; init; }
    public int ManModuleModeId { get; init; }
    public int MaintainableModeId { get; init; }

}