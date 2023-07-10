using FlightSchoolTss.Data.DTOs.SoftwareSystem;
using FlightSchoolTss.Data.DTOs.SoftwareVersion;
using Fluxor;

namespace FlightSchoolCm.UI.Components.Software.Store;

public class SoftwareFeature : Feature<SoftwareState>
{
    public override string GetName() => "Software";

    protected override SoftwareState GetInitialState()
    {
        return new SoftwareState
        {
            ButtonTextSystem = "ADD",
            ButtonTextVersion = "ADD",
            SoftwareSystemDto = new SoftwareSystemDto(),
            SoftwareVersionDto = new SoftwareVersionDto(),
            SoftwareSystemDtos = new List<SoftwareSystemDto>(),
            SoftwareVersionDtos = new List<SoftwareVersionDto>(),
            SelectedSystemId = 0,
            SelectedVersionId = 0,
            SelectedPlatform = 0
        };
    }
}