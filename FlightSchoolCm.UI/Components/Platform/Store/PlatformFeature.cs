using FlightSchoolTss.Data.DTOs.Platform;
using Fluxor;

namespace FlightSchoolCm.UI.Components.Platform.Store;

public class PlatformFeature : Feature<PlatformState>
{
    public override string GetName() => "Platform";

    protected override PlatformState GetInitialState()
    {
        return new PlatformState
        {
            ButtonText = "ADD",
            PlatformDto = new PlatformDto(),
            PlatformDtos = new List<PlatformDto>()
        };
    }
}