using FlightSchoolTss.Data.DTOs.Simulator;

namespace FlightSchoolCm.UI.Components.Simulator.Store;

public record SimulatorState
{
    public List<SimulatorDto>? SimulatorDtos { get; init; } = new List<SimulatorDto>();
    public SimulatorDto? SimulatorDto { get; init; } = new SimulatorDto();
    public string ButtonText { get; init; } = "ADD";
    public int PlatformId { get; set; } = 0;
}