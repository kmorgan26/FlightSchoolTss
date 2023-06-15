using Fluxor;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public record MaintainerModeState
{
    public int MaintainerModeId { get; init; }

}

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

public class MaintainerModeChangeAction { }

public static class MaintainerModeReducers
{
    [ReducerMethod(typeof(MaintainerModeChangeAction))]
    public static MaintainerModeState OnChange(MaintainerModeState state)
    {
        return state with
        {
            MaintainerModeId = state.MaintainerModeId + 1
        };
    }
}