using FlightSchoolTss.Data.DTOs.SoftwareSystem;
using FlightSchoolTss.Data.DTOs.SoftwareVersion;

namespace FlightSchoolCm.UI.Components.Software.Store;

public class SoftwareButtonTextSystemChangeAction
{
    public string ButtonText { get; init; } = "ADD";
}
public class SoftwareButtonTextVersionChangeAction
{
    public string ButtonText { get; init; } = "ADD";
}
public class SoftwareSystemDtoChangeAction
{
    public SoftwareSystemDto? SoftwareSystemDto { get; init; } = new SoftwareSystemDto();
}
public class SoftwareVersionDtoChangeAction
{
    public SoftwareVersionDto? SoftwareVersionDto { get; init; } = new SoftwareVersionDto();
}
public class SoftwareSystemDtosChangeAction
{
    public IEnumerable<SoftwareSystemDto>? SoftwareSystemDtos { get; init; }
}
public class SoftwareVersionDtosChangeAction
{
    public IEnumerable<SoftwareVersionDto>? SoftwareVersionDtos { get; init; }
}
public class SelectedSystemIdChangeAction
{
    public int SelectedSystemId { get; init; } = 0;
}
public class SelectedVersionIdChangeAction
{
    public int SelectedVersionId { get; init; } = 0;
}
public class SelectedPlatformChangeAction
{
    public int SelectedPlatform { get; init; } = 0;
}
