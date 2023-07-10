using Fluxor;

namespace FlightSchoolCm.UI.Components.Software.Store;

public class SoftwareReducer
{
    
    [ReducerMethod] public static SoftwareState SoftwareSystemDtoChangeAction(SoftwareState state, SoftwareSystemDtoChangeAction action)
    {
        return state with
        {
            SoftwareSystemDto = action.SoftwareSystemDto!,
            ButtonTextSystem = state.ButtonTextSystem,
            ButtonTextVersion = state.ButtonTextVersion,
            SelectedSystemId = state.SelectedSystemId,
            SelectedVersionId = state.SelectedVersionId,
            SelectedPlatform = state.SelectedPlatform,
            SoftwareSystemDtos = state.SoftwareSystemDtos,
            SoftwareVersionDtos = state.SoftwareVersionDtos,
            SoftwareVersionDto = state.SoftwareVersionDto
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareVersionDtoChangeAction(SoftwareState state, SoftwareVersionDtoChangeAction action)
    {
        return state with
        {
            SoftwareVersionDto = action.SoftwareVersionDto!,
            SelectedVersionId = state.SelectedVersionId,
            SoftwareSystemDto = state.SoftwareSystemDto,
            ButtonTextSystem = state.ButtonTextSystem,
            ButtonTextVersion = state.ButtonTextVersion,
            SelectedSystemId = state.SelectedSystemId,
            SelectedPlatform = state.SelectedPlatform,
            SoftwareSystemDtos = state.SoftwareSystemDtos,
            SoftwareVersionDtos = state.SoftwareVersionDtos,
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareSystemDtosChangeAction(SoftwareState state, SoftwareSystemDtosChangeAction action)
    {
        return state with
        {
            SoftwareSystemDtos = action.SoftwareSystemDtos!,
            SoftwareVersionDto = state.SoftwareVersionDto,
            SelectedVersionId = state.SelectedVersionId,
            SoftwareSystemDto = state.SoftwareSystemDto,
            ButtonTextSystem = state.ButtonTextSystem,
            ButtonTextVersion = state.ButtonTextVersion,
            SelectedSystemId = state.SelectedSystemId,
            SelectedPlatform = state.SelectedPlatform,
            SoftwareVersionDtos = state.SoftwareVersionDtos,
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareVersionDtosChangeAction(SoftwareState state, SoftwareVersionDtosChangeAction action)
    {
        return state with
        {
            SoftwareVersionDtos = action.SoftwareVersionDtos!,
            SoftwareVersionDto = state.SoftwareVersionDto,
            SelectedVersionId = state.SelectedVersionId,
            SoftwareSystemDto = state.SoftwareSystemDto,
            ButtonTextSystem = state.ButtonTextSystem,
            ButtonTextVersion = state.ButtonTextVersion,
            SelectedSystemId = state.SelectedSystemId,
            SelectedPlatform = state.SelectedPlatform,
            SoftwareSystemDtos = state.SoftwareSystemDtos,
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareSelectedSystemIdChangeAction(SoftwareState state, SelectedSystemIdChangeAction action)
    {
        return state with
        {
            SelectedSystemId = action.SelectedSystemId!,
            SoftwareSystemDto = state.SoftwareSystemDto,
            ButtonTextSystem = state.ButtonTextSystem,
            ButtonTextVersion = state.ButtonTextVersion,
            SelectedVersionId = state.SelectedVersionId,
            SelectedPlatform = state.SelectedPlatform,
            SoftwareSystemDtos = state.SoftwareSystemDtos,
            SoftwareVersionDtos = state.SoftwareVersionDtos,
            SoftwareVersionDto = state.SoftwareVersionDto
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareSelectedVersionIdChangeAction(SoftwareState state, SelectedVersionIdChangeAction action)
    {
        return state with
        {
            SelectedVersionId = action.SelectedVersionId!,
            SelectedSystemId = state.SelectedSystemId,
            SoftwareSystemDto = state.SoftwareSystemDto,
            ButtonTextSystem = state.ButtonTextSystem,
            ButtonTextVersion = state.ButtonTextVersion,
            SelectedPlatform = state.SelectedPlatform,
            SoftwareSystemDtos = state.SoftwareSystemDtos,
            SoftwareVersionDtos = state.SoftwareVersionDtos,
            SoftwareVersionDto = state.SoftwareVersionDto
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareSelectedPlatformChangeAction(SoftwareState state, SelectedPlatformChangeAction action)
    {
        return state with
        {
            SelectedPlatform = action.SelectedPlatform!,
            SelectedVersionId = state.SelectedVersionId,
            SelectedSystemId = state.SelectedSystemId,
            SoftwareSystemDto = state.SoftwareSystemDto,
            ButtonTextSystem = state.ButtonTextSystem,
            ButtonTextVersion = state.ButtonTextVersion,
            SoftwareSystemDtos = state.SoftwareSystemDtos,
            SoftwareVersionDtos = state.SoftwareVersionDtos,
            SoftwareVersionDto = state.SoftwareVersionDto

        };
    }
    [ReducerMethod] public static SoftwareState SoftwareButtonTextSystemChangeAction(SoftwareState state, SoftwareButtonTextSystemChangeAction action)
    {
        return state with
        {
            ButtonTextSystem = action.ButtonText!,
            SelectedPlatform = state.SelectedPlatform,
            SelectedVersionId = state.SelectedVersionId,
            SelectedSystemId = state.SelectedSystemId,
            SoftwareSystemDto = state.SoftwareSystemDto,
            ButtonTextVersion = state.ButtonTextVersion,
            SoftwareSystemDtos = state.SoftwareSystemDtos,
            SoftwareVersionDtos = state.SoftwareVersionDtos,
            SoftwareVersionDto = state.SoftwareVersionDto
        };
    }
    [ReducerMethod] public static SoftwareState SoftwareButtonTextVersionChangeAction(SoftwareState state, SoftwareButtonTextVersionChangeAction action)
    {
        return state with
        {
            ButtonTextVersion = action.ButtonText!,
            ButtonTextSystem = state.ButtonTextSystem,
            SelectedPlatform = state.SelectedPlatform,
            SelectedVersionId = state.SelectedVersionId,
            SelectedSystemId = state.SelectedSystemId,
            SoftwareSystemDto = state.SoftwareSystemDto,
            SoftwareSystemDtos = state.SoftwareSystemDtos,
            SoftwareVersionDtos = state.SoftwareVersionDtos,
            SoftwareVersionDto = state.SoftwareVersionDto
        };
    }
}
