﻿using FlightSchoolTss.Data.DTOs.Maintainer;
using Fluxor;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public static class MaintainerModeReducers
{
    [ReducerMethod]
    public static MaintainableModeState OnChangeMaintainableModeId(MaintainableModeState state, MaintainableModeIdChange action)
    {
        return state with
        {
            MaintainableModeId = action.MaintainableModeId,
            MaintainerId = state.MaintainerId,
            LotModeId = state.LotModeId,
            ManModuleModeId = state.ManModuleModeId,
            SimulatorModeId = state.SimulatorModeId,
            PlatformModeId = state.PlatformModeId,
            MaintainerDtos = state.MaintainerDtos
        };
    }

    [ReducerMethod]
    public static MaintainableModeState OnChangeMaintainerModeId(MaintainableModeState state, MaintainerModeIdChange action)
    {
        return state with
        {
            MaintainerId = action.MaintainerModeId,
            MaintainableModeId = state.MaintainableModeId,
            LotModeId = state.LotModeId,
            ManModuleModeId = state.ManModuleModeId,
            SimulatorModeId = state.SimulatorModeId,
            PlatformModeId = state.PlatformModeId,
            MaintainerDtos = state.MaintainerDtos
        };
    }
    [ReducerMethod]
    public static MaintainableModeState OnChangeLotModeId(MaintainableModeState state, LotModeIdChange action)
    {
        return state with
        {
            LotModeId = action.LotModeId,
            MaintainerId = state.MaintainerId,
            MaintainableModeId = state.MaintainableModeId,
            ManModuleModeId = state.ManModuleModeId,
            SimulatorModeId = state.SimulatorModeId,
            PlatformModeId = state.PlatformModeId,
            MaintainerDtos = state.MaintainerDtos
        };
    }

    [ReducerMethod]
    public static MaintainableModeState OnChangeManModuleModeId(MaintainableModeState state, ManModuleModeIdChange action)
    {
        return state with
        {
            ManModuleModeId = action.ManModuleModeId,
            MaintainerId = state.MaintainerId,
            MaintainableModeId = state.MaintainableModeId,
            LotModeId = state.LotModeId,
            SimulatorModeId = state.SimulatorModeId,
            PlatformModeId = state.PlatformModeId,
            MaintainerDtos = state.MaintainerDtos
        };
    }

    [ReducerMethod]
    public static MaintainableModeState OnChangeSimulatorModeId(MaintainableModeState state, SimulatorModeIdChange action)
    {
        return state with
        {
            SimulatorModeId = action.SimulatorModeId,
            ManModuleModeId = state.ManModuleModeId,
            MaintainerId = state.MaintainerId,
            MaintainableModeId = state.MaintainableModeId,
            LotModeId = state.LotModeId,
            PlatformModeId = state.PlatformModeId,
            MaintainerDtos = state.MaintainerDtos
        };
    }

    [ReducerMethod]
    public static MaintainableModeState OnChangePlatformModeId(MaintainableModeState state, PlatformModeIdChange action)
    {
        return state with
        {
            PlatformModeId = action.PlatformModeId,
            SimulatorModeId = state.SimulatorModeId,
            ManModuleModeId = state.ManModuleModeId,
            MaintainerId = state.MaintainerId,
            MaintainableModeId = state.MaintainableModeId,
            LotModeId = state.LotModeId,
            MaintainerDtos = state.MaintainerDtos
        };
    }
}