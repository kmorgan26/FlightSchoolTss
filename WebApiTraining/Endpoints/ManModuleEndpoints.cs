using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Lot;
using WebApiTraining.DTOs.Maintainer;
using WebApiTraining.DTOs.ManModule;
using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.Endpoints;

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

        group.MapPost("/", async (CreateManModuleDto createManModuleDto, IManModuleRepository repo, IMapper mapper, IValidator<CreateManModuleDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(createManModuleDto);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.ToDictionary());

            var manModule = mapper.Map<ManModule>(createManModuleDto);
            await repo.AddAsync(manModule);
            return TypedResults.Created($"/api/manmodule/{manModule.Id}", createManModuleDto);
        })
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
