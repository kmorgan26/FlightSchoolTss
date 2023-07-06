using System.ComponentModel.DataAnnotations;

namespace FlightSchoolTss.Data.DTOs.SoftwareSystem;

public class SoftwareSystemDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "The name cannot be more than 50 characters")]
    [MinLength(3, ErrorMessage = "Please use at least 3 characters for the name")]
    public string Name { get; set; } = null!;
    public int MaintainableId { get; set; }

}
