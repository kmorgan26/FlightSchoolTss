using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Data.DTOs.HardwareVersion;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class HardwareVersionEndpoints
{
    public static void MapHardwareVersionEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/hardwareversion").WithTags(nameof(HardwareVersion));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var versions = await unitOfWork.HardwareVersions.GetAllAsync();
            return mapper.Map<List<HardwareVersionDto>>(versions);
        })
        .WithTags(nameof(HardwareVersion))
        .WithName("GetAllHardwareVersions")
        .Produces<List<HardwareVersionDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.HardwareVersions.GetAsync(id)
                is HardwareVersion model
                    ? Results.Ok(mapper.Map<HardwareVersionDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(HardwareVersion))
        .WithName("GetHardwareVersionById")
        .Produces<HardwareVersionDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", [AllowAnonymous] async (int id, HardwareVersionDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.HardwareVersions.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(dto, foundModel);

            await unitOfWork.HardwareVersions.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(HardwareVersion))
        .WithName("UpdateHardwareVersion")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [AllowAnonymous] async (HardwareVersionDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var hwSystem = mapper.Map<HardwareVersion>(dto);
            await unitOfWork.HardwareVersions.AddAsync(hwSystem);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/HardwareVersion/{hwSystem.Id}", hwSystem);
        })
        .AddEndpointFilter<ValidationFilter<HardwareVersionDto>>()
        .WithTags(nameof(HardwareVersion))
        .WithName("CreateHardwareVersion")
        .Produces<HardwareVersion>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.HardwareVersions.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(HardwareVersion))
        .WithName("DeleteHardwareVersion")
        .Produces<HardwareVersion>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}