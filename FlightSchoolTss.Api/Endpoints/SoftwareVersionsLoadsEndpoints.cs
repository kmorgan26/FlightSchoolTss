using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Api.DTOs.SoftwareVersionLoad;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class SoftwareVersionLoadEndpoints
{
    public static void MapSoftwareVersionLoadEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/softwareversionload").WithTags(nameof(SoftwareVersionLoad));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var versionsLoads = await unitOfWork.SoftwareVersionsLoads.GetAllAsync();
            return mapper.Map<List<SoftwareVersionLoadDto>>(versionsLoads);
        })
        .WithTags(nameof(SoftwareVersionLoad))
        .WithName("GetAllSoftwareVersionLoad")
        .Produces<List<SoftwareVersionLoadDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.SoftwareVersionsLoads.GetAsync(id)
                is SoftwareVersionLoad model
                    ? Results.Ok(mapper.Map<SoftwareVersionLoadDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(SoftwareVersionLoad))
        .WithName("GetSoftwareVersionLoadById")
        .Produces<SoftwareVersionLoadDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, SoftwareVersionLoadDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.SoftwareVersionsLoads.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(dto, foundModel);

            await unitOfWork.SoftwareVersionsLoads.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(SoftwareVersionLoad))
        .WithName("UpdateSoftwareVersionLoad")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateSoftwareVersionLoadDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var config = mapper.Map<SoftwareVersionLoad>(dto);
            await unitOfWork.SoftwareVersionsLoads.AddAsync(config);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/SoftwareVersionLoad/{config.Id}", config);
        })
        .AddEndpointFilter<ValidationFilter<CreateSoftwareVersionLoadDto>>()
        .WithTags(nameof(SoftwareVersionLoad))
        .WithName("CreateSoftwareVersionLoad")
        .Produces<SoftwareVersionLoad>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.SoftwareVersionsLoads.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(SoftwareVersionLoad))
        .WithName("DeleteSoftwareVersionLoad")
        .Produces<SoftwareVersionLoad>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}