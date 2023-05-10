using AutoMapper;
using FluentValidation;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Platform;
using WebApiTraining.DTOs.Simulator;
using WebApiTraining.Filters;

namespace WebApiTraining.Endpoints;
public static class SimulatorEndpoints
{
    public static void MapSimulatorEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/simulator").WithTags(nameof(Simulator));

        group.MapGet("/", async (ISimulatorRepository repo, IMapper mapper) =>
        {
            var simulators = await repo.GetAllAsync();
            return mapper.Map<List<SimulatorDto>>(simulators);
        })
        .WithTags(nameof(Simulator))
        .WithName("GetAllSimulators")
        .Produces<List<SimulatorDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, ISimulatorRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is Simulator model
                    ? Results.Ok(mapper.Map<SimulatorDto>(model))
                    : Results.NotFound();

        })
        .WithTags(nameof(Simulator))
        .WithName("GetSimulatorById")
        .Produces<SimulatorDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetByPlatform/{id}", async (int id, ISimulatorRepository repo, IMapper mapper) =>
        {
            return await repo.GetAllSimulatorsByPlatformIdAsync(id)
                is List<Simulator> model
                    ? Results.Ok(mapper.Map<List<SimulatorDto>>(model))
                    : Results.NotFound();

        })
        .WithTags(nameof(Simulator))
        .WithName("GetSimulatorsByPlatformId")
        .Produces<SimulatorDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, SimulatorDto simulatorDto, ISimulatorRepository repo, IMapper mapper) =>
        {
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(simulatorDto, foundModel);

            await repo.UpdateAsync(foundModel.Id);
            return Results.NoContent();
        })
        .WithTags(nameof(Simulator))
        .WithName("UpdateSimulator")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateSimulatorDto createSimulatorDto, ISimulatorRepository repo, IMapper mapper) =>
        {
            var simulator = mapper.Map<Simulator>(createSimulatorDto);
            await repo.AddAsync(simulator);
            return Results.Created($"/api/Simulator/{simulator.Id}", simulator);
        })
        .AddEndpointFilter<ValidationFilter<CreateSimulatorDto>>()
        .WithTags(nameof(Simulator))
        .WithName("CreateSimulator")
        .Produces<Simulator>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, ISimulatorRepository repo) =>
        {
            return await repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Simulator))
        .WithName("DeleteSimulator")
        .Produces<Simulator>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}