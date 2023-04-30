using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
namespace WebApiTraining.Endpoints;

public static class MaintainerEndpoints
{
    public static void MapMaintainerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/maintainer").WithTags(nameof(Maintainer));

        group.MapGet("/", async (FstssDataContext db) =>
        {
            return await db.Maintainers.ToListAsync();
        })
        .WithName("GetAllMaintainers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Maintainer>, NotFound>> (int id, FstssDataContext db) =>
        {
            return await db.Maintainers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Maintainer model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMaintainerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Maintainer maintainer, FstssDataContext db) =>
        {
            var affected = await db.Maintainers
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Name, maintainer.Name)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMaintainer")
        .WithOpenApi();

        group.MapPost("/", async (Maintainer maintainer, FstssDataContext db) =>
        {
            db.Maintainers.Add(maintainer);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/maintainer/{maintainer.Id}",maintainer);
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
