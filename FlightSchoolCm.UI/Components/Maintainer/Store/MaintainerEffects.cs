using FlightSchoolCm.UI.Interfaces;
using FlightSchoolTss.Data.DTOs.Maintainer;
using Fluxor;

namespace FlightSchoolCm.UI.Components.Maintainer.Store;

public class MaintainerEffects
{
    private readonly IGenericApiClient<MaintainerDto> _apiClient;

    public MaintainerEffects(IGenericApiClient<MaintainerDto> apiClient)
    {
        _apiClient = apiClient;
    }

    [EffectMethod]
    public async Task CreateOrUpdateAsync(MaintainerCreateOrUpdateAction action, IDispatcher dispatcher)
    {
        var _dto = action.MaintainerDto;

        if (_dto!.Id == 0)
        {
            await _apiClient.CreateAsync(_dto!);
        }
        else
        {
            await _apiClient.UpdateAsync(_dto!.Id, _dto!);
        }

        dispatcher.Dispatch(new MaintainerCollectionChangeAction
        {
            MaintainerDtos = await _apiClient.GetAllAsync(),
            IsAdd = true
        });

        dispatcher.Dispatch(new MaintainerDtoChangeAction
        {
            MaintainerDto = new MaintainerDto(),
            IsAdd = true
        });

    }
}