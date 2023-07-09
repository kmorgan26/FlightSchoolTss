using FlightSchoolTss.Data.DTOs.Simulator;
using Fluxor;

namespace FlightSchoolCm.UI.Components.Simulator.Store;

public class SimulatorFeature : Feature<SimulatorState>
{
    public override string GetName() => "Simulator";

    protected override SimulatorState GetInitialState()
    {
        return new SimulatorState
        {
            ButtonText = "ADD",
            SimulatorDto = new SimulatorDto(),
            SimulatorDtos = new List<SimulatorDto>(),
            PlatformId = 0
        };
    }
}