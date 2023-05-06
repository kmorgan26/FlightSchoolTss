using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Maintainer;

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
        .WithName("GetAllMaintainers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<MaintainerDto>, NotFound>> (int id, IMaintainerRepository repo, IMapper mapper) =>
        {
            var maintainer = await repo.GetAsync(id);

            if (maintainer == null) return TypedResults.NotFound();

            var result = mapper.Map<MaintainerDto>(maintainer);

            return TypedResults.Ok(result);

        })
        .WithName("GetMaintainerById")
        .WithOpenApi();

        group.MapPut("/{id}", async (int id, MaintainerDto maintainerDto, IMaintainerRepository repo, IMapper mapper) =>
        {
            var affected = await repo.GetAsync(id);

            if (affected is null) 
                return Results.NotFound();
            
            mapper.Map(maintainerDto, affected);
            await repo.UpdateAsync(maintainerDto.Id);

            return Results.NoContent();
        })
        .WithName("UpdateMaintainer")
        .WithOpenApi();

        group.MapPost("/", async (CreateMaintainerDto maintainerDto, IMaintainerRepository repo, IMapper mapper) =>
        {
            var maintainer = mapper.Map<Maintainer>(maintainerDto);
            await repo.AddAsync(maintainer);
            return TypedResults.Created($"/api/maintainer/{maintainer.Id}", maintainerDto);
        })
        .WithName("CreateMaintainer")
        .WithOpenApi();

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
