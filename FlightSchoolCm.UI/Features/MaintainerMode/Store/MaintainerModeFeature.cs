using Fluxor;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public class MaintainerModeFeature : Feature<MaintainerModeState>
{
    public override string GetName() => "MaintainerMode";

    protected override MaintainerModeState GetInitialState()
    {
        return new MaintainerModeState
        {
            MaintainerModeId = 0
        };
    }
}


