using System.ComponentModel.DataAnnotations;

namespace FlightSchoolTss.Data.DTOs.Platform;
public class PlatformDto
{
    public int Id { get; set; } = 0;

    [Required]
    [MaxLength(50, ErrorMessage = "The name cannot be more than 50 characters")]
    [MinLength(3, ErrorMessage = "Please use at least 3 characters for the name")]
    public string Name { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    [Required(ErrorMessage = "Please select a maintainer")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select a Maintainer")]
    public int MaintainerId { get; set; } = 0;

    public int MaintainableId { get; set; } = 0;

    public string Maintainer { get; set; } = null!;
}