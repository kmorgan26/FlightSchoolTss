using FlightSchoolTss.Data.DTOs.Simulator;

namespace FlightSchoolCm.UI.Components.Simulator.Store;

public class SimulatorButtonTextChangeAction
{
    public string ButtonText { get; init; } = "ADD";
}
public class SimulatorDtoChangeAction
{
    public SimulatorDto? SimulatorDto { get; init; } = new SimulatorDto();
}

public class SimulatorDtosChangeAction
{
    public List<SimulatorDto>? SimulatorDtos { get; init; } = new List<SimulatorDto>();
}
public class SimulatorPlatformIdChangeAction
{
    public int PlatformId { get; set; } = 0;
}