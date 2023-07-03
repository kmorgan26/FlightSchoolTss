using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Data.DTOs.SoftwareVersion;
using Microsoft.AspNetCore.Authorization;
using FlightSchoolTss.Data.DTOs.SoftwareSystem;

namespace FlightSchoolTss.Endpoints;
public static class SoftwareVersionEndpoints
{
    public static void MapSoftwareVersionEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/softwareversion").WithTags(nameof(SoftwareVersion));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var versions = await unitOfWork.SoftwareVersions.GetAllAsync();
            return mapper.Map<List<SoftwareVersionDto>>(versions);
        })
        .WithTags(nameof(SoftwareVersion))
        .WithName("GetAllSoftwareVersions")
        .Produces<List<SoftwareVersionDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.SoftwareVersions.GetAsync(id)
                is SoftwareVersion model
                    ? Results.Ok(mapper.Map<SoftwareVersionDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(SoftwareVersion))
        .WithName("GetSoftwareVersionById")
        .Produces<SoftwareVersionDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", [AllowAnonymous] async (int id, SoftwareVersionDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.SoftwareVersions.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(dto, foundModel);

            await unitOfWork.SoftwareVersions.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(SoftwareVersion))
        .WithName("UpdateSoftwareVersion")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [AllowAnonymous] async (SoftwareVersionDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var config = mapper.Map<SoftwareVersion>(dto);
            await unitOfWork.SoftwareVersions.AddAsync(config);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/SoftwareVersion/{config.Id}", config);
        })
        .AddEndpointFilter<ValidationFilter<SoftwareVersionDto>>()
        .WithTags(nameof(SoftwareVersion))
        .WithName("CreateSoftwareVersion")
        .Produces<SoftwareVersion>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.SoftwareVersions.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(SoftwareVersion))
        .WithName("DeleteSoftwareVersion")
        .Produces<SoftwareVersion>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetSoftwareVersionsBySoftwareSystemId/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var softwareVersions = await unitOfWork.SoftwareVersions.GetSoftwareVersionsBySoftwareSystemIdAsync(id);
            return mapper.Map<IEnumerable<SoftwareVersionDto>>(softwareVersions);
        })
        .WithTags(nameof(SoftwareVersion))
        .WithName("GetSoftwareVersionsBySoftwareSystemId")
        .Produces<SoftwareVersionDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

    }
}