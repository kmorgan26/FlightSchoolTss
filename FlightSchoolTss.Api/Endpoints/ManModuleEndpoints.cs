using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.DTOs.ManModule;
using FlightSchoolTss.Filters;

namespace FlightSchoolTss.Endpoints;

public static class ManModuleEndpoints
{
    public static void MapManModuleEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/manmodule").WithTags(nameof(ManModule));

        group.MapGet("/", async (IManModuleRepository repo, IMapper mapper) =>
        {
            var manModules = await repo.GetAllAsync();
            return mapper.Map<List<ManModuleDto>>(manModules);
        })
        .WithTags(nameof(ManModule))
        .WithName("GetAllManModules")
        .Produces<List<ManModuleDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IManModuleRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is ManModule model
                    ? Results.Ok(mapper.Map<ManModuleDto>(model))
                    : Results.NotFound();

        })
        .WithTags(nameof(ManModule))
        .WithName("GetManModuleById")
        .Produces<ManModuleDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, ManModuleDto manModuleDto, IManModuleRepository repo, IMapper mapper) =>
        {
            var affected = await repo.GetAsync(id);

            if (affected is null)
                return Results.NotFound();

            mapper.Map(manModuleDto, affected);
            await repo.UpdateAsync(manModuleDto.Id);

            return Results.NoContent();
        })
        .WithTags(nameof(ManModule))
        .WithName("UpdateManModule")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateManModuleDto createManModuleDto, IManModuleRepository repo, IMapper mapper) =>
        {
            var manModule = mapper.Map<ManModule>(createManModuleDto);
            await repo.AddAsync(manModule);
            return TypedResults.Created($"/api/manmodule/{manModule.Id}", createManModuleDto);
        })
        .AddEndpointFilter<ValidationFilter<CreateManModuleDto>>()
        .WithTags(nameof(ManModule))
        .WithName("CreateManModule")
        .Produces<ManModule>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IManModuleRepository repo) =>
        {
            return await repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(ManModule))
        .WithName("DeleteManModule")
        .Produces<ManModule>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

    }
}
