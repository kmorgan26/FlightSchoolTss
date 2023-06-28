using Fluxor;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

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