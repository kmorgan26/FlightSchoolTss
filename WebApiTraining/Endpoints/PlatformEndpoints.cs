using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;

namespace WebApiTraining.Endpoints;

public static class PlatformEndpoints
{
    public static void MapPlatformEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Platform").WithTags(nameof(Platform));

        group.MapGet("/", async (FstssDataContext db) =>
        {
            return await db.Platforms.ToListAsync();
        })
        .WithName("GetAllPlatforms")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Platform>, NotFound>> (int id, FstssDataContext db) =>
        {
            return await db.Platforms.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Platform model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPlatformById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Platform platform, FstssDataContext db) =>
        {
            var affected = await db.Platforms
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.IsActive, platform.IsActive)
                  .SetProperty(m => m.Id, platform.Id)
                  .SetProperty(m => m.Name, platform.Name)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePlatform")
        .WithOpenApi();

        group.MapPost("/", async (Platform platform, FstssDataContext db) =>
        {
            db.Platforms.Add(platform);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Platform/{platform.Id}", platform);
        })
        .WithName("CreatePlatform")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, FstssDataContext db) =>
        {
            var affected = await db.Platforms
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePlatform")
        .WithOpenApi();
    }
}
