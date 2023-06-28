using FlightSchoolTss.Data.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace FlightSchoolTss.Data.DTOs.Maintainer;
public class MaintainerDto : BaseDtoViewModel
{
    private int _id;
    public override int Id { get => Id = _id; set => _id = value; }

    [Required, 
        MaxLength(50, ErrorMessage = "The name cannot be more than 50 characters"), 
        MinLength(3, ErrorMessage = "Please use at least 3 characters for the name")]
    public override string Name { get => base.Name; set => base.Name = value; }
}