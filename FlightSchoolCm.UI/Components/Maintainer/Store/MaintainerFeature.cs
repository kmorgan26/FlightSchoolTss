using FlightSchoolCm.UI.Components.Maintainer.Store;
using FlightSchoolTss.Data.DTOs.Maintainer;
using Fluxor;

public class MaintainerFeature : Feature<MaintainerState>
{
    public override string GetName() => "Maintainer";

    protected override MaintainerState GetInitialState()
    {
        return new MaintainerState
        {
            ButtonText = "ADD",
            MaintainerDto = new MaintainerDto(),
            MaintainerDtos = new List<MaintainerDto>()
        };
    }
}