using Fluxor;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public class ModeFeature : Feature<ModeState>
{
    public override string GetName() => "MaintainerMode";

    protected override ModeState GetInitialState()
    {
        return new ModeState
        {
            MaintainerId = 0,
            MaintainableModeId = 0,
            ManModuleId = 0,
            PlatformId = 0,
            SimulatorId = 0,
            LotId = 0
        };
    }
}


