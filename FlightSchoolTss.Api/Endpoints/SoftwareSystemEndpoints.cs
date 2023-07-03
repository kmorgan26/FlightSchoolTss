using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Data.DTOs.SoftwareSystem;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class SoftwareSystemEndpoints
{
    public static void MapSoftwareSystemEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/softwaresystem").WithTags(nameof(SoftwareSystem));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var systems = await unitOfWork.SoftwareSystems.GetAllAsync();
            return mapper.Map<List<SoftwareSystemDto>>(systems);
        })
        .WithTags(nameof(SoftwareSystem))
        .WithName("GetAllSoftwareSystems")
        .Produces<List<SoftwareSystemDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.SoftwareSystems.GetAsync(id)
                is SoftwareSystem model
                    ? Results.Ok(mapper.Map<SoftwareSystemDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(SoftwareSystem))
        .WithName("GetSoftwareSystemById")
        .Produces<SoftwareSystemDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", [AllowAnonymous] async (int id, SoftwareSystemDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.SoftwareSystems.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(dto, foundModel);

            await unitOfWork.SoftwareSystems.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(SoftwareSystem))
        .WithName("UpdateSoftwareSystem")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [AllowAnonymous] async (SoftwareSystemDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var config = mapper.Map<SoftwareSystem>(dto);
            await unitOfWork.SoftwareSystems.AddAsync(config);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/SoftwareSystem/{config.Id}", config);
        })
        .AddEndpointFilter<ValidationFilter<SoftwareSystemDto>>()
        .WithTags(nameof(SoftwareSystem))
        .WithName("CreateSoftwareSystem")
        .Produces<SoftwareSystem>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.SoftwareSystems.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(SoftwareSystem))
        .WithName("DeleteSoftwareSystem")
        .Produces<SoftwareSystem>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetSoftwareSystemsByMaintainableId/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var softwareSystems = await unitOfWork.SoftwareSystems.GetSoftwareSystemsByMaintainableIdAsync(id);
            return mapper.Map<IEnumerable<SoftwareSystemDto>>(softwareSystems);
        })
        .WithTags(nameof(SoftwareSystem))
        .WithName("GetSoftwareSystemsByMaintainableId")
        .Produces<SoftwareSystemDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}