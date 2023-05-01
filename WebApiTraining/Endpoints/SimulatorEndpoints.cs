using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using AutoMapper;
using WebApiTraining.DTOs.Simulator;

namespace WebApiTraining.Endpoints;

public static class SimulatorEndpoints
{
    public static void MapSimulatorEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/simulator").WithTags(nameof(Simulator));

        group.MapGet("/", async (FstssDataContext db, IMapper mapper) =>
        {
            var simulators = await db.Simulators.ToListAsync();
            return mapper.Map<List<SimulatorDto>>(simulators);
        })
        .WithName("GetAllSimulators")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<SimulatorDto>, NotFound>> (int id, FstssDataContext db, IMapper mapper) =>
        {
            var simulator = await db.Simulators.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id);

            var result = mapper.Map<SimulatorDto>(simulator);

            return simulator is null ? TypedResults.NotFound() : TypedResults.Ok(result);

        })
        .WithName("GetSimulatorById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, SimulatorDto simulatorDto, FstssDataContext db) =>
        {
            var affected = await db.Simulators
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Alias, simulatorDto.Alias)
                  .SetProperty(m => m.PlatformId, simulatorDto.PlatformId)
                  .SetProperty(m => m.IsActive, simulatorDto.IsActive)
                  .SetProperty(m => m.Name, simulatorDto.Name)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSimulator")
        .WithOpenApi();

        group.MapPost("/", async (CreateSimulatorDto createSimulatorDto, FstssDataContext db, IMapper mapper) =>
        {
            var simulator = mapper.Map<Simulator>(createSimulatorDto);
            db.Simulators.Add(simulator);

            await db.SaveChangesAsync();
            
            var result = mapper.Map<SimulatorDto>(simulator);
            return TypedResults.Created($"/api/simulator/{simulator.Id}", result);
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
