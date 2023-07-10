using FlightSchoolTss.Data.DTOs.SoftwareSystem;
using FlightSchoolTss.Data.DTOs.SoftwareVersion;

namespace FlightSchoolCm.UI.Components.Software.Store;

public record SoftwareState
{
    public int SelectedPlatform { get; init; } = 0;
    public int SelectedSystemId { get; init; } = 0;
    public int SelectedVersionId { get; init; } = 0;
    public string ButtonTextSystem { get; init; } = "ADD";
    public string ButtonTextVersion { get; init; } = "ADD";

    public SoftwareSystemDto SoftwareSystemDto { get; init; } = new();

    public SoftwareVersionDto SoftwareVersionDto { get; init; } = new();

    public IEnumerable<SoftwareSystemDto> SoftwareSystemDtos { get; set; } = new List<SoftwareSystemDto>();
    public IEnumerable<SoftwareVersionDto> SoftwareVersionDtos { get; set; } = new List<SoftwareVersionDto>();
}
