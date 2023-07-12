using Fluxor;

namespace FlightSchoolCm.UI.Components.Software.Store;

public static class SoftwareReducer
{
    
    [ReducerMethod] public static SoftwareState SoftwareSystemDtoChangeAction(SoftwareState state, SoftwareSystemDtoChangeAction action)
    {
        return state with
        {
            SoftwareSystemDto = action.SoftwareSystemDto!
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareVersionDtoChangeAction(SoftwareState state, SoftwareVersionDtoChangeAction action)
    {
        return state with
        {
            SoftwareVersionDto = action.SoftwareVersionDto!
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareSystemDtosChangeAction(SoftwareState state, SoftwareSystemDtosChangeAction action)
    {
        return state with
        {
            SoftwareSystemDtos = action.SoftwareSystemDtos!
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareVersionDtosChangeAction(SoftwareState state, SoftwareVersionDtosChangeAction action)
    {
        return state with
        {
            SoftwareVersionDtos = action.SoftwareVersionDtos!
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareSelectedSystemIdChangeAction(SoftwareState state, SelectedSystemIdChangeAction action)
    {
        return state with
        {
            SelectedSystemId = action.SelectedSystemId!
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareSelectedVersionIdChangeAction(SoftwareState state, SelectedVersionIdChangeAction action)
    {
        return state with
        {
            SelectedVersionId = action.SelectedVersionId!
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareSelectedPlatformChangeAction(SoftwareState state, SelectedMaintainableChangeAction action)
    {
        return state with
        {
            SelectedMaintainable = action.SelectedMaintainable!

        };
    }
    [ReducerMethod] public static SoftwareState SoftwareButtonTextSystemChangeAction(SoftwareState state, SoftwareButtonTextSystemChangeAction action)
    {
        return state with
        {
            ButtonTextSystem = action.ButtonText!
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareButtonTextVersionChangeAction(SoftwareState state, SoftwareButtonTextVersionChangeAction action)
    {
        return state with
        {
            ButtonTextVersion = action.ButtonText!
        };
    }
}
