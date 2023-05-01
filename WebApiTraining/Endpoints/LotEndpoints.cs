using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
namespace WebApiTraining.Endpoints;

public static class LotEndpoints
{
    public static void MapLotEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/lot").WithTags(nameof(Lot));

        group.MapGet("/", async (FstssDataContext db) =>
        {
            return await db.Lots.ToListAsync();
        })
        .WithName("GetAllLots")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Lot>, NotFound>> (int id, FstssDataContext db) =>
        {
            return await db.Lots.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Lot model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetLotById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Lot lot, FstssDataContext db) =>
        {
            var affected = await db.Lots
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.PlatformId, lot.PlatformId)
                  .SetProperty(m => m.Name, lot.Name)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateLot")
        .WithOpenApi();

        group.MapPost("/", async (Lot lot, FstssDataContext db) =>
        {
            db.Lots.Add(lot);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/lot/{lot.Id}",lot);
        })
        .WithName("CreateLot")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, FstssDataContext db) =>
        {
            var affected = await db.Lots
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteLot")
        .WithOpenApi();
    }
}