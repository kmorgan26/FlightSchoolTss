using Fluxor;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public class MaintainerModeFeature : Feature<MaintainableModeState>
{
    public override string GetName() => "MaintainerMode";

    protected override MaintainableModeState GetInitialState()
    {
        return new MaintainableModeState
        {
            MaintainerModeId = 0,
            MaintainableModeId = 0,
            ManModuleModeId = 0,
            PlatformModeId = 0,
            SimulatorModeId = 0,
            LotModeId = 0,
            MaintainerDtos = new()
        };
    }
}


