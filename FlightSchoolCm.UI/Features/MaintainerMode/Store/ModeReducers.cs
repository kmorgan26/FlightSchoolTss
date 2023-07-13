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
            MaintainableModeId = action.MaintainableModeId
        };
    }

    [ReducerMethod]
    public static ModeState OnChangeMaintainerId(ModeState state, MaintainerIdChange action)
    {
        return state with
        {
            MaintainerId = action.MaintainerModeId,
            PlatformId = 0,
            LotId = 0,
            ManModuleId = 0
        };
    }
    [ReducerMethod]
    public static ModeState OnChangeLotId(ModeState state, LotIdChange action)
    {
        return state with
        {
            LotId = action.LotModeId
        };
    }

    [ReducerMethod]
    public static ModeState OnChangeManModuleId(ModeState state, ManModuleIdChange action)
    {
        return state with
        {
            ManModuleId = action.ManModuleModeId
        };
    }

    [ReducerMethod]
    public static ModeState OnChangeSimulatorId(ModeState state, SimulatorIdChange action)
    {
        return state with
        {
            SimulatorId = action.SimulatorModeId
        };
    }

    [ReducerMethod]
    public static ModeState OnChangePlatformId(ModeState state, PlatformIdChange action)
    {
        return state with
        {
            PlatformId = action.PlatformModeId
        };
    }
}