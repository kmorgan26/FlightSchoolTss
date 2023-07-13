using FlightSchoolTss.Data.DTOs.Maintainer;
using Fluxor;

namespace FlightSchoolCm.UI.Components.Maintainer.Store;

public static class MaintainerReducer
{
    [ReducerMethod]
    public static MaintainerState OnDtoChange(MaintainerState state, MaintainerDtoChangeAction action)
    {
        string buttonText = action.IsAdd ? "ADD" : "UPDATE";
        string messageText = action.IsAdd ? "Created" : "Updated";
        var dto = action.MaintainerDto is not null ? action.MaintainerDto : new MaintainerDto();
        
        return state with
        {
            MaintainerDto = dto,
            ButtonText = buttonText,
            Message = messageText!
        };
    }
    
    [ReducerMethod]
    public static MaintainerState OnCollectionChange(MaintainerState state, MaintainerCollectionChangeAction action)
    {
        var buttonText = action.IsAdd ? "ADD" : "UPDATE";
        return state with
        {
            MaintainerDtos = action.MaintainerDtos!,
            ButtonText = buttonText
        };
    }
}