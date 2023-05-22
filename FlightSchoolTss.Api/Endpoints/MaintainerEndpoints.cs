using AutoMapper;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.DTOs.Maintainer;
using FlightSchoolTss.Filters;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class MaintainerEndpoints
{
    public static void MapMaintainerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/maintainer").WithTags(nameof(Maintainer));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var maintainers = await unitOfWork.Maintainers.GetAllAsync();
            return mapper.Map<List<MaintainerDto>>(maintainers);
        })
        .WithTags(nameof(Maintainer))
        .WithName("GetAllMaintainers")
        .Produces<List<MaintainerDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.Maintainers.GetAsync(id)
                is Maintainer model
                    ? Results.Ok(mapper.Map<MaintainerDto>(model))
                    : Results.NotFound();

        })
        .WithTags(nameof(Maintainer))
        .WithName("GetMaintainerById")
        .Produces<MaintainerDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapGet("/GetMaintainersWithPlatformDetails", async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var maintainers = await unitOfWork.Maintainers.GetMaintainersWithPlatformDetailsAsync();
            return mapper.Map<List<MaintainerDetailsDto>>(maintainers);
        })
        .WithTags(nameof(Maintainer))
        .WithName("GetMaintainersWithPlatformDetails")
        .Produces<List<MaintainerDetailsDto>>(StatusCodes.Status200OK);

        group.MapPut("/{id}", async (int id, MaintainerDto maintainerDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var affected = await unitOfWork.Maintainers.GetAsync(id);

            if (affected is null)
                return Results.NotFound();

            mapper.Map(maintainerDto, affected);
            await unitOfWork.Maintainers.UpdateAsync(maintainerDto.Id);

            return Results.NoContent();
        })
        .WithTags(nameof(Maintainer))
        .WithName("UpdateMaintainer")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateMaintainerDto maintainerDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var maintainer = mapper.Map<Maintainer>(maintainerDto);
            await unitOfWork.Maintainers.AddAsync(maintainer);
            return TypedResults.Created($"/api/maintainer/{maintainer.Id}", maintainerDto);
        })
        .AddEndpointFilter<ValidationFilter<CreateMaintainerDto>>()
        .AddEndpointFilter<LoggingFilter>()
        .WithTags(nameof(Maintainer))
        .WithName("CreateMaintainer")
        .Produces<Maintainer>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IUnitOfWork unitOfWork) =>
        {
            return await unitOfWork.Maintainers.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Maintainer))
        .WithName("DeleteMaintainer")
        .Produces<Maintainer>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}