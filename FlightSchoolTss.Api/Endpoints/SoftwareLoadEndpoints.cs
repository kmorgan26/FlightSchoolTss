using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Data.DTOs.SoftwareLoad;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class SoftwareLoadEndpoints
{
    public static void MapSoftwareLoadEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/softwareload").WithTags(nameof(SoftwareLoad));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var loads = await unitOfWork.SoftwareLoads.GetAllAsync();
            return mapper.Map<List<SoftwareLoadDto>>(loads);
        })
        .WithTags(nameof(SoftwareLoad))
        .WithName("GetAllSoftwareLoads")
        .Produces<List<SoftwareLoadDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.SoftwareLoads.GetAsync(id)
                is SoftwareLoad model
                    ? Results.Ok(mapper.Map<SoftwareLoadDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(SoftwareLoad))
        .WithName("GetSoftwareLoadById")
        .Produces<SoftwareLoadDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, SoftwareLoadDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.SoftwareLoads.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(dto, foundModel);

            await unitOfWork.SoftwareLoads.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(SoftwareLoad))
        .WithName("UpdateSoftwareLoad")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateSoftwareLoadDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var config = mapper.Map<SoftwareLoad>(dto);
            await unitOfWork.SoftwareLoads.AddAsync(config);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/SoftwareLoad/{config.Id}", config);
        })
        .AddEndpointFilter<ValidationFilter<CreateSoftwareLoadDto>>()
        .WithTags(nameof(SoftwareLoad))
        .WithName("CreateSoftwareLoad")
        .Produces<SoftwareLoad>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.SoftwareLoads.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(SoftwareLoad))
        .WithName("DeleteSoftwareLoad")
        .Produces<SoftwareLoad>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}