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

public class MaintainerModeChangeAction 
{
    public int Value { get; set; }
}

public static class MaintainerModeReducers
{
    [ReducerMethod]
    public static MaintainerModeState OnChange(MaintainerModeState state, MaintainerModeChangeAction action)
    {
        return state with
        {
            MaintainerModeId = action.Value
        };
    }
}