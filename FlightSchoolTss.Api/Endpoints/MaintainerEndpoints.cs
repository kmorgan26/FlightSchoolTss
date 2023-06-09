﻿using AutoMapper;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Data.DTOs.Maintainer;
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

        group.MapGet("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
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

        group.MapGet("/GetMaintainersWithPlatformDetails", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var maintainers = await unitOfWork.Maintainers.GetMaintainersWithPlatformDetailsAsync();
            return mapper.Map<List<MaintainerDetailsDto>>(maintainers);
        })
        .WithTags(nameof(Maintainer))
        .WithName("GetMaintainersWithPlatformDetails")
        .Produces<List<MaintainerDetailsDto>>(StatusCodes.Status200OK);

        group.MapPut("/{id}", [AllowAnonymous] async (int id, MaintainerDto maintainerDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var affected = await unitOfWork.Maintainers.GetAsync(id);

            if (affected is null)
                return Results.NotFound();

            mapper.Map(maintainerDto, affected);
            await unitOfWork.Maintainers.UpdateAsync(maintainerDto.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(Maintainer))
        .WithName("UpdateMaintainer")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [AllowAnonymous] async (MaintainerDto maintainerDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var maintainer = mapper.Map<Maintainer>(maintainerDto);
            await unitOfWork.Maintainers.AddAsync(maintainer);
            await unitOfWork.CommitAsync();
            return TypedResults.Created($"/api/maintainer/{maintainer.Id}", maintainer);
        })
        .AddEndpointFilter<ValidationFilter<MaintainerDto>>()
        .AddEndpointFilter<LoggingFilter>()
        .WithTags(nameof(Maintainer))
        .WithName("CreateMaintainer")
        .Produces<Maintainer>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.Maintainers.DeleteAsync(id);
            await unitOfWork.CommitAsync();
            
            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Maintainer))
        .WithName("DeleteMaintainer")
        .Produces<Maintainer>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}