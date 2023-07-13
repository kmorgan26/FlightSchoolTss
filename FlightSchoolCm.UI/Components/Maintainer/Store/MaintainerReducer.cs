using FlightSchoolTss.Data.DTOs.Maintainer;
using Fluxor;

namespace FlightSchoolCm.UI.Components.Maintainer.Store;

public static class MaintainerReducer
{
    [ReducerMethod]
    public static MaintainerState OnDtoChange(MaintainerState state, MaintainerDtoChangeAction action)
    {
        var buttonText = action.IsAdd ? "ADD" : "UPDATE";
        var dto = action.MaintainerDto is not null ? action.MaintainerDto : new MaintainerDto();
        
        return state with
        {
            MaintainerDto = dto,
            ButtonText = buttonText
        };
    }
    
    [ReducerMethod]
    public static MaintainerState OnCollectionChange(MaintainerState state, MaintainerCollectionChangeAction action)
    {
        var buttonText = action.IsAdd ? "ADD" : "UPDATE";
        return state with
        {
            MaintainerDtos = action.MaintainerDtos!,
            ButtonText = buttonText,
        };
    }
}