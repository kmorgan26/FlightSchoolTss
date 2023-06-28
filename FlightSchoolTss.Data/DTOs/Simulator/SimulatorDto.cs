using System.ComponentModel.DataAnnotations;

namespace FlightSchoolTss.Data.DTOs.Simulator;
public class SimulatorDto
{
    public int Id { get; set; }

    [Required,
        MaxLength(50, ErrorMessage = "The name cannot be more than 50 characters"),
        MinLength(3, ErrorMessage = "Please use at least 3 characters for the name")]
    public string Name { get; set; } = null!;
    public string Alias { get; set; } = null!;

    [Required(ErrorMessage = "Please select a Platform"),
        Range(0, int.MaxValue, ErrorMessage = "Please Select a Platform")]
    public int PlatformId { get; set; }
    public int MaintainableId { get; set; }
    public bool IsActive { get; set; }
}