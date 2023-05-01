using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.DTOs.Maintainer;

namespace WebApiTraining.Endpoints;

public static class MaintainerEndpoints
{
    public static void MapMaintainerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/maintainer").WithTags(nameof(Maintainer));

        group.MapGet("/", async (FstssDataContext db, IMapper mapper) =>
        {
            var maintainers = await db.Maintainers.ToListAsync();
            return mapper.Map<List<MaintainerDto>>(maintainers);
        })
        .WithName("GetAllMaintainers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<MaintainerDto>, NotFound>> (int id, FstssDataContext db, IMapper mapper) =>
        {
            var maintainer = await db.Maintainers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id);

            if (maintainer == null) return TypedResults.NotFound();

            var result = mapper.Map<MaintainerDto>(maintainer);

            return TypedResults.Ok(result);

        })
        .WithName("GetMaintainerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, MaintainerDto maintainerDto, FstssDataContext db, IMapper mapper) =>
        {
            var maintainer = mapper.Map<Maintainer>(maintainerDto);

            var affected = await db.Maintainers
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Name, maintainer.Name)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMaintainer")
        .WithOpenApi();

        group.MapPost("/", async (CreateMaintainerDto maintainerDto, FstssDataContext db, IMapper mapper) =>
        {
            var maintainer = mapper.Map<Maintainer>(maintainerDto);
            db.Maintainers.Add(maintainer);
            
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/maintainer/{maintainer.Id}", maintainer);
        })
        .WithName("CreateMaintainer")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, FstssDataContext db) =>
        {
            var affected = await db.Maintainers
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteMaintainer")
        .WithOpenApi();
    }
}
