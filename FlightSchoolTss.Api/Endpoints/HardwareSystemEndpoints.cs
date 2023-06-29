using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Data.DTOs.HardwareSystem;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class HardwareSystemEndpoints
{
    public static void MapHardwareSystemEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/hardwaresystem").WithTags(nameof(HardwareSystem));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var systems = await unitOfWork.HardwareSystems.GetAllAsync();
            return mapper.Map<List<HardwareSystemDto>>(systems);
        })
        .WithTags(nameof(HardwareSystem))
        .WithName("GetAllHardwareSystems")
        .Produces<List<HardwareSystemDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.HardwareSystems.GetAsync(id)
                is HardwareSystem model
                    ? Results.Ok(mapper.Map<HardwareSystemDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(HardwareSystem))
        .WithName("GetHardwareSystemById")
        .Produces<HardwareSystemDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", [AllowAnonymous] async (int id, HardwareSystemDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.HardwareSystems.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(dto, foundModel);

            await unitOfWork.HardwareSystems.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(HardwareSystem))
        .WithName("UpdateHardwareSystem")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [AllowAnonymous] async (HardwareSystemDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var hwSystem = mapper.Map<HardwareSystem>(dto);
            await unitOfWork.HardwareSystems.AddAsync(hwSystem);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/HardwareSystem/{hwSystem.Id}", hwSystem);
        })
        .AddEndpointFilter<ValidationFilter<HardwareSystemDto>>()
        .WithTags(nameof(HardwareSystem))
        .WithName("CreateHardwareSystem")
        .Produces<HardwareSystem>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.HardwareSystems.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(HardwareSystem))
        .WithName("DeleteHardwareSystem")
        .Produces<HardwareSystem>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}