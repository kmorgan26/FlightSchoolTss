using Fluxor;

namespace FlightSchoolCm.UI.Components.Maintainer.Store;

public class MaintainerReducer
{
    [ReducerMethod]
    public static MaintainerState OnDtoChange(MaintainerState state, MaintainerDtoChangeAction action)
    {
        return state with
        {
            MaintainerDto = action.MaintainerDto,
            MaintainerDtos = state.MaintainerDtos,
            ButtonText = state.ButtonText
        };
    }

    [ReducerMethod]
    public static MaintainerState OnButtonTextChange(MaintainerState state, MaintainerButtonTextChangeAction action)
    {
        return state with
        {
            ButtonText = action.ButtonText!,
            MaintainerDtos = state.MaintainerDtos,
            MaintainerDto = state.MaintainerDto
        };
    }

    [ReducerMethod]
    public static MaintainerState OnCollectionChange(MaintainerState state, MaintainerCollectionChangeAction action)
    {
        return state with
        {
            MaintainerDtos = action.MaintainerDtos!,
            MaintainerDto = state.MaintainerDto,
            ButtonText = state.ButtonText
        };
    }
    [ReducerMethod]
    public static MaintainerState OnSelectedRowChange(MaintainerState state, MaintainerSelectedRowChangeAction action)
    {
        return state with
        {
            MaintainerDtos = state.MaintainerDtos!,
            MaintainerDto = state.MaintainerDto,
            ButtonText = state.ButtonText,
            SelectedRow = action.SelectedRow
        };
    }
}
