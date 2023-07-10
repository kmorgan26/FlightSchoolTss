using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public class MaintainerModeIdChange 
{
    public int MaintainerModeId { get; set; } = 0;
}
public class PlatformModeIdChange
{
    public int PlatformModeId { get; set; } = 0;
}

public class SimulatorModeIdChange
{
    public int SimulatorModeId { get; set; } = 0;
}
public class LotModeIdChange
{
    public int LotModeId { get; set; } = 0;
}
public class ManModuleModeIdChange
{
    public int ManModuleModeId { get; set; } = 0;
}
public class MaintainableModeIdChange
{
    public int MaintainableModeId { get; set; } = 0;
}

public class MaintainerDtosChange
{
    public List<MaintainerDto>? MaintainerDtos { get; set; } = new List<MaintainerDto>();
}
