using FlightSchoolTss.Data.DTOs.Maintainer;

namespace FlightSchoolCm.UI.Components.Maintainer.Store;

public class MaintainerButtonTextChangeAction
{
    public string? ButtonText { get; set; }
}
public class MaintainerCollectionChangeAction
{
    public List<MaintainerDto>? MaintainerDtos { get; set; }
    public bool IsAdd { get; set; }
}
public class MaintainerDtoChangeAction
{
    public MaintainerDto? MaintainerDto { get; set; }
    public bool IsAdd { get; set; }
}
public class MaintainerSelectedRowChangeAction
{
    public int SelectedRow { get; set; }
}