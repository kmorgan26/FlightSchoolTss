using FlightSchoolTss.Data.DTOs.Maintainer;
using Fluxor;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public static class ModeReducers
{
    [ReducerMethod]
    public static ModeState OnChangeMaintainableModeId(ModeState state, MaintainableIdChange action)
    {
        return state with
        {
            MaintainableModeId = action.MaintainableModeId,
            MaintainerId = state.MaintainerId,
            LotId = state.LotId,
            ManModuleId = state.ManModuleId,
            SimulatorId = state.SimulatorId,
            PlatformId = state.PlatformId,
            MaintainerDtos = state.MaintainerDtos
        };
    }

    [ReducerMethod]
    public static ModeState OnChangeMaintainerId(ModeState state, MaintainerIdChange action)
    {
        return state with
        {
            MaintainerId = action.MaintainerModeId,
            MaintainableModeId = state.MaintainableModeId,
            LotId = state.LotId,
            ManModuleId = state.ManModuleId,
            SimulatorId = state.SimulatorId,
            PlatformId = state.PlatformId,
            MaintainerDtos = state.MaintainerDtos
        };
    }
    [ReducerMethod]
    public static ModeState OnChangeLotId(ModeState state, LotIdChange action)
    {
        return state with
        {
            LotId = action.LotModeId,
            MaintainerId = state.MaintainerId,
            MaintainableModeId = state.MaintainableModeId,
            ManModuleId = state.ManModuleId,
            SimulatorId = state.SimulatorId,
            PlatformId = state.PlatformId,
            MaintainerDtos = state.MaintainerDtos
        };
    }

    [ReducerMethod]
    public static ModeState OnChangeManModuleId(ModeState state, ManModuleIdChange action)
    {
        return state with
        {
            ManModuleId = action.ManModuleModeId,
            MaintainerId = state.MaintainerId,
            MaintainableModeId = state.MaintainableModeId,
            LotId = state.LotId,
            SimulatorId = state.SimulatorId,
            PlatformId = state.PlatformId,
            MaintainerDtos = state.MaintainerDtos
        };
    }

    [ReducerMethod]
    public static ModeState OnChangeSimulatorId(ModeState state, SimulatorIdChange action)
    {
        return state with
        {
            SimulatorId = action.SimulatorModeId,
            ManModuleId = state.ManModuleId,
            MaintainerId = state.MaintainerId,
            MaintainableModeId = state.MaintainableModeId,
            LotId = state.LotId,
            PlatformId = state.PlatformId,
            MaintainerDtos = state.MaintainerDtos
        };
    }

    [ReducerMethod]
    public static ModeState OnChangePlatformId(ModeState state, PlatformIdChange action)
    {
        return state with
        {
            PlatformId = action.PlatformModeId,
            SimulatorId = state.SimulatorId,
            ManModuleId = state.ManModuleId,
            MaintainerId = state.MaintainerId,
            MaintainableModeId = state.MaintainableModeId,
            LotId = state.LotId,
            MaintainerDtos = state.MaintainerDtos
        };
    }
}