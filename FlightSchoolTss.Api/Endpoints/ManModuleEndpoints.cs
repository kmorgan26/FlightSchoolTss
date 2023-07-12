using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Data.DTOs.ManModule;
using FlightSchoolTss.Filters;
using Microsoft.AspNetCore.Authorization;
using FlightSchoolTss.Data.DTOs.Simulator;

namespace FlightSchoolTss.Endpoints;

public static class ManModuleEndpoints
{
    public static void MapManModuleEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/manmodule").WithTags(nameof(ManModule));

        group.MapGet("/",[AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var manModules = await unitOfWork.ManModules.GetAllAsync();
            return mapper.Map<List<ManModuleDto>>(manModules);
        })
        .WithTags(nameof(ManModule))
        .WithName("GetAllManModules")
        .Produces<List<ManModuleDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.ManModules.GetAsync(id)
                is ManModule model
                    ? Results.Ok(mapper.Map<ManModuleDto>(model))
                    : Results.NotFound();

        })
        .WithTags(nameof(ManModule))
        .WithName("GetManModuleById")
        .Produces<ManModuleDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetByLotIdAsync/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.ManModules.GetManModulesByLotIdAsync(id)
                is List<ManModule> model
                    ? Results.Ok(mapper.Map<List<ManModuleDto>>(model))
                    : Results.NotFound();

        })
        .WithTags(nameof(ManModule))
        .WithName("GetManModulesByLotId")
        .Produces<ManModuleDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);



        group.MapPut("/{id}", [AllowAnonymous] async (int id, ManModuleDto manModuleDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var affected = await unitOfWork.ManModules.GetAsync(id);

            if (affected is null)
                return Results.NotFound();

            mapper.Map(manModuleDto, affected);
            await unitOfWork.ManModules.UpdateAsync(manModuleDto.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(ManModule))
        .WithName("UpdateManModule")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [AllowAnonymous] async (ManModuleDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var manModule = mapper.Map<ManModule>(dto);
            await unitOfWork.ManModules.AddAsync(manModule);
            await unitOfWork.CommitAsync();

            return TypedResults.Created($"/api/manmodule/{manModule.Id}", dto);
        })
        .AddEndpointFilter<ValidationFilter<ManModuleDto>>()
        .WithTags(nameof(ManModule))
        .WithName("CreateManModule")
        .Produces<ManModule>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.ManModules.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(ManModule))
        .WithName("DeleteManModule")
        .Produces<ManModule>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

    }
}
