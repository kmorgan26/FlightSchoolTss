using AutoMapper;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.Endpoints;

public static class PlatformEndpoints
{
    public static void MapPlatformEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Platform").WithTags(nameof(Platform));

        group.MapGet("/", async (IPlatformRepository repo, IMapper mapper) =>
        {
            var platforms = await repo.GetAllAsync();
            return mapper.Map<List<PlatformDto>>(platforms);
        })
        .WithTags(nameof(Platform))
        .WithName("GetAllPlatforms")
        .Produces<List<PlatformDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IPlatformRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is Platform model
                    ? Results.Ok(mapper.Map<PlatformDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Platform))
        .WithName("GetPlatformById")
        .Produces<PlatformDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, PlatformDto platformDto, IPlatformRepository repo, IMapper mapper) =>
        {
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(platformDto, foundModel);
            await repo.UpdateAsync(foundModel.Id);
            return Results.NoContent();
        })
        .WithTags(nameof(Platform))
        .WithName("UpdatePlatform")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/GetByMaintainerId/{id}", async (int id, IPlatformRepository repo, IMapper mapper) =>
        {
            return await repo.GetPlatformsByMaintainerIdAsync(id)
                is List<Platform> model
                    ? Results.Ok(mapper.Map<List<PlatformDto>>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Platform))
        .WithName("GetPlatformsByMaintainerId")
        .Produces<PlatformDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/GetPlatformsWithSimulatorDetails", async (IPlatformRepository repo, IMapper mapper) =>
        {
            var platforms = await repo.GetPlatformsWithSimulatorDetailsAsync();
            return mapper.Map<List<PlatformDetailsDto>>(platforms);
        })
        .WithTags(nameof(Platform))
        .WithName("GetPlatformsWithSimulatorDetails")
        .Produces<List<PlatformDetailsDto>>(StatusCodes.Status200OK);

        group.MapPost("/", async (CreatePlatformDto createPlatformDto, IPlatformRepository repo, IMapper mapper) =>
        {
            var platform = mapper.Map<Platform>(createPlatformDto);
            await repo.AddAsync(platform);
            return Results.Created($"/api/Platform/{platform.Id}", platform);
        })
        .WithTags(nameof(Platform))
        .WithName("CreatePlatform")
        .Produces<Platform>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IPlatformRepository repo) =>
        {
            return await repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Platform))
        .WithName("DeletePlatform")
        .Produces<Platform>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}