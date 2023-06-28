using AutoMapper;
using FlightSchoolTss.Data.DTOs.Simulator;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FluentValidation;

namespace FlightSchoolTss.Endpoints;
public static class SimulatorEndpoints
{
    public static void MapSimulatorEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/simulator").WithTags(nameof(Simulator));

        group.MapGet("/", async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var simulators = await unitOfWork.Simulators.GetAllAsync();
            return mapper.Map<List<SimulatorDto>>(simulators);
        })
        .WithTags(nameof(Simulator))
        .WithName("GetAllSimulators")
        .Produces<List<SimulatorDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.Simulators.GetAsync(id)
                is Simulator model
                    ? Results.Ok(mapper.Map<SimulatorDto>(model))
                    : Results.NotFound();

        })
        .WithTags(nameof(Simulator))
        .WithName("GetSimulatorById")
        .Produces<SimulatorDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetByPlatform/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.Simulators.GetAllSimulatorsByPlatformIdAsync(id)
                is List<Simulator> model
                    ? Results.Ok(mapper.Map<List<SimulatorDto>>(model))
                    : Results.NotFound();

        })
        .WithTags(nameof(Simulator))
        .WithName("GetSimulatorsByPlatformId")
        .Produces<SimulatorDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, SimulatorDto simulatorDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.Simulators.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(simulatorDto, foundModel);

            await unitOfWork.Simulators.UpdateAsync(foundModel.Id);
            return Results.NoContent();
        })
        .WithTags(nameof(Simulator))
        .WithName("UpdateSimulator")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateSimulatorDto createSimulatorDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var simulator = mapper.Map<Simulator>(createSimulatorDto);
            await unitOfWork.Simulators.AddAsync(simulator);
            return Results.Created($"/api/Simulator/{simulator.Id}", simulator);
        })
        .AddEndpointFilter<ValidationFilter<CreateSimulatorDto>>()
        .WithTags(nameof(Simulator))
        .WithName("CreateSimulator")
        .Produces<Simulator>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.Simulators.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Simulator))
        .WithName("DeleteSimulator")
        .Produces<Simulator>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}