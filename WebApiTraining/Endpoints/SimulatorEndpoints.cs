using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;

namespace WebApiTraining.Endpoints;

public static class SimulatorEndpoints
{
    public static void MapSimulatorEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/simulator").WithTags(nameof(Simulator));

        group.MapGet("/", async (FstssDataContext db) =>
        {
            return await db.Simulators.ToListAsync();
        })
        .WithName("GetAllSimulators")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Simulator>, NotFound>> (int id, FstssDataContext db) =>
        {
            return await db.Simulators.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Simulator model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSimulatorById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Simulator simulator, FstssDataContext db) =>
        {
            var affected = await db.Simulators
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Alias, simulator.Alias)
                  .SetProperty(m => m.PlatformId, simulator.PlatformId)
                  .SetProperty(m => m.IsActive, simulator.IsActive)
                  .SetProperty(m => m.Name, simulator.Name)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSimulator")
        .WithOpenApi();

        group.MapPost("/", async (Simulator simulator, FstssDataContext db) =>
        {
            db.Simulators.Add(simulator);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/simulator/{simulator.Id}", simulator);
        })
        .WithName("CreateSimulator")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, FstssDataContext db) =>
        {
            var affected = await db.Simulators
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSimulator")
        .WithOpenApi();
    }
}
