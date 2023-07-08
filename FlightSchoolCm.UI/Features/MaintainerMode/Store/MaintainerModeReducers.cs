using Fluxor;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public static class MaintainerModeReducers
{
    [ReducerMethod]
    public static MaintainerModeState OnChangeId(MaintainerModeState state, MaintainerModeChangeAction action)
    {
        return state with
        {
            MaintainerModeId = action.MaintainerModeId,
            MaintainerDtos = state.MaintainerDtos
        };
    }

    [ReducerMethod]
    public static MaintainerModeState OnGetDtos(MaintainerModeState state, GetMaintainerDtosAction action)
    {
        return state with
        {
            MaintainerModeId = state.MaintainerModeId,
            MaintainerDtos = action.MaintainerDtos
        };
    }
}