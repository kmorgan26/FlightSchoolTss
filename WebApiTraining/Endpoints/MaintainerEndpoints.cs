using AutoMapper;
using FluentValidation;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Lot;
using WebApiTraining.DTOs.Maintainer;
using WebApiTraining.Filters;

namespace WebApiTraining.Endpoints;
public static class MaintainerEndpoints
{
    public static void MapMaintainerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/maintainer").WithTags(nameof(Maintainer));

        group.MapGet("/", async (IMaintainerRepository repo, IMapper mapper) =>
        {
            var maintainers = await repo.GetAllAsync();
            return mapper.Map<List<MaintainerDto>>(maintainers);
        })
        .WithTags(nameof(Maintainer))
        .WithName("GetAllMaintainers")
        .Produces<List<MaintainerDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IMaintainerRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is Maintainer model
                    ? Results.Ok(mapper.Map<MaintainerDto>(model))
                    : Results.NotFound();

        })
        .WithTags(nameof(Maintainer))
        .WithName("GetMaintainerById")
        .Produces<MaintainerDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetMaintainersWithPlatformDetails", async (IMaintainerRepository repo, IMapper mapper) =>
        {
            var maintainers = await repo.GetMaintainersWithPlatformDetailsAsync();
            return mapper.Map<List<MaintainerDetailsDto>>(maintainers);
        })
        .WithTags(nameof(Maintainer))
        .WithName("GetMaintainersWithPlatformDetails")
        .Produces<List<MaintainerDetailsDto>>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (int id, MaintainerDto maintainerDto, IMaintainerRepository repo, IMapper mapper) =>
        {
            var affected = await repo.GetAsync(id);

            if (affected is null)
                return Results.NotFound();

            mapper.Map(maintainerDto, affected);
            await repo.UpdateAsync(maintainerDto.Id);

            return Results.NoContent();
        })
        .WithTags(nameof(Maintainer))
        .WithName("UpdateMaintainer")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateMaintainerDto maintainerDto, IMaintainerRepository repo, IMapper mapper) =>
        {
            var maintainer = mapper.Map<Maintainer>(maintainerDto);
            await repo.AddAsync(maintainer);
            return TypedResults.Created($"/api/maintainer/{maintainer.Id}", maintainerDto);
        })
        .AddEndpointFilter<ValidationFilter<CreateMaintainerDto>>()
        .AddEndpointFilter<LoggingFilter>()
        .WithTags(nameof(Maintainer))
        .WithName("CreateMaintainer")
        .Produces<Maintainer>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IMaintainerRepository repo) =>
        {
            return await repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Maintainer))
        .WithName("DeleteMaintainer")
        .Produces<Maintainer>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}