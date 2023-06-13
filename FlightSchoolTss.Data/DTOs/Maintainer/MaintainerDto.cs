using FlightSchoolTss.Data.Abstractions;
using FlightSchoolTss.Data.DTOs.Abstractions;

namespace FlightSchoolTss.DTOs.Maintainer;
public class MaintainerDto : BaseDtoViewModel
{
    private int _id;
    public override int Id { get => Id = _id; set => _id = value; }
}