using Fluxor;

namespace FlightSchoolCm.UI.Components.Simulator.Store;

public class SimulatorReducer
{
    [ReducerMethod]
    public static SimulatorState SimulatorButtonTextChangeAction(SimulatorState state, SimulatorButtonTextChangeAction action)
    {
        return state with
        {
            ButtonText = action.ButtonText,
            SimulatorDto = state.SimulatorDto,
            SimulatorDtos = state.SimulatorDtos,
            PlatformId = state.PlatformId,
        };
    }
    [ReducerMethod]
    public static SimulatorState SimulatorDtoChangeAction(SimulatorState state, SimulatorDtoChangeAction action)
    {
        return state with
        {
            ButtonText = state.ButtonText,
            SimulatorDto = action.SimulatorDto,
            SimulatorDtos = state.SimulatorDtos,
            PlatformId = state.PlatformId,
        };
    }
    [ReducerMethod]
    public static SimulatorState SimulatorDtosChangeAction(SimulatorState state, SimulatorDtosChangeAction action)
    {
        return state with
        {
            ButtonText = state.ButtonText,
            SimulatorDto = state.SimulatorDto,
            SimulatorDtos = action.SimulatorDtos,
            PlatformId = state.PlatformId,
        };
    }
    [ReducerMethod]
    public static SimulatorState PlatformIdChangeAction(SimulatorState state, SimulatorPlatformIdChangeAction action)
    {
        return state with
        {
            ButtonText = state.ButtonText,
            SimulatorDto = state.SimulatorDto,
            SimulatorDtos = state.SimulatorDtos,
            PlatformId = action.PlatformId,
        };
    }
    
}
