using AutoMapper;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Maintainer;
using WebApiTraining.DTOs.ManModule;

namespace WebApiTraining.Endpoints;

public static class ManModuleEndpoints
{
    public static void MapManModuleEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/manmodule").WithTags(nameof(ManModule));

        group.MapGet("/", async (IManModuleRepository repo, IMapper mapper) =>
        {
            var manModules = await repo.GetAllAsync();
            return mapper.Map<List<ManModuleDto>>(manModules);
        })
        .WithTags(nameof(ManModule))
        .WithName("GetAllManModules")
        .Produces<List<MaintainerDto>>(StatusCodes.Status200OK);

    }
}
