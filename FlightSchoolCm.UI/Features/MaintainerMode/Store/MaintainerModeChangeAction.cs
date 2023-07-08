using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolCm.UI.Features.MaintainerMode.Store;

public class MaintainerModeChangeAction 
{
    public int MaintainerModeId { get; set; }
}

public class GetMaintainerDtosAction
{
    public List<MaintainerDto>? MaintainerDtos { get; set; }
}
