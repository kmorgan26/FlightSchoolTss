using Fluxor;

namespace FlightSchoolCm.UI.Components.Platform.Store;

public class PlatformReducer
{
    [ReducerMethod]
    public static PlatformState ButtonTextChangeAction(PlatformState state, PlatformButtonTextChangeAction action)
    {
        return state with 
        { 
            ButtonText = action.ButtonText,
            PlatformDto = state.PlatformDto,
            PlatformDtos = state.PlatformDtos
        };
    }

    [ReducerMethod]
    public static PlatformState PlatformDtoChangeAction(PlatformState state, PlatformDtoChangeAction action)
    {
        return state with 
        { 
            PlatformDto = action.PlatformDto,
            PlatformDtos = state.PlatformDtos,
            ButtonText = state.ButtonText
        };
    }

    [ReducerMethod]
    public static PlatformState PlatformDtosChangeAction(PlatformState state, PlatformDtosChangeAction action)
    {
        return state with
        {
            PlatformDtos = action.PlatformDtos,
            PlatformDto = state.PlatformDto,
            ButtonText = state.ButtonText
        };
    }
    [ReducerMethod]
    public static PlatformState MaintainerIdChangeAction(PlatformState state, PlatformMaintainerIdChangeAction action)
    {
        return state with
        {
            MaintainerId = action.MaintainerId,
            PlatformDtos = state.PlatformDtos,
            PlatformDto = state.PlatformDto,
            ButtonText = state.ButtonText
        };
    }
}
