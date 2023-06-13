using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.ViewModels.Maintainer;

public class MaintainerVm : BaseDtoViewModel
{
    private int _id;
    public override int Id { get => Id = _id; set => _id = value; }
}
