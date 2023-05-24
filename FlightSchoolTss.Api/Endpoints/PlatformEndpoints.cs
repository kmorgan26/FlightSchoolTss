using AutoMapper;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.DTOs.Platform;
using FlightSchoolTss.Filters;
using FluentValidation;

namespace FlightSchoolTss.Endpoints;

public static class PlatformEndpoints
{
    
    public static void MapPlatformEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/platform").WithTags(nameof(Platform));

        group.MapGet("/", async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var platforms = await unitOfWork.Platforms.GetAllAsync();
            return mapper.Map<List<PlatformDto>>(platforms);
        })
        .WithTags(nameof(Platform))
        .WithName("GetAllPlatforms")
        .Produces<List<PlatformDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.Platforms.GetAsync(id)
                is Platform model
                    ? Results.Ok(mapper.Map<PlatformDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Platform))
        .WithName("GetPlatformById")
        .Produces<PlatformDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, PlatformDto platformDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var affected = await unitOfWork.Platforms.GetAsync(id);

            if (affected is null)
                return Results.NotFound();

            mapper.Map(platformDto, affected);
            await unitOfWork.Platforms.UpdateAsync(platformDto.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(Platform))
        .WithName("UpdatePlatform")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/GetByMaintainerId/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.Platforms.GetPlatformsByMaintainerIdAsync(id)
                is List<Platform> model
                    ? Results.Ok(mapper.Map<List<PlatformDto>>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Platform))
        .WithName("GetPlatformsByMaintainerId")
        .Produces<PlatformDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/GetPlatformsWithSimulatorDetails", async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var platforms = await unitOfWork.Platforms.GetPlatformsWithSimulatorDetailsAsync();
            return mapper.Map<List<PlatformDetailsDto>>(platforms);
        })
        .WithTags(nameof(Platform))
        .WithName("GetPlatformsWithSimulatorDetails")
        .Produces<List<PlatformDetailsDto>>(StatusCodes.Status200OK);

        group.MapPost("/", async (CreatePlatformDto createPlatformDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var platform = mapper.Map<Platform>(createPlatformDto);
            await unitOfWork.Platforms.AddAsync(platform);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/Platform/{platform.Id}", platform);
        })
        .AddEndpointFilter<ValidationFilter<CreatePlatformDto>>()
        .WithTags(nameof(Platform))
        .WithName("CreatePlatform")
        .Produces<Platform>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.Platforms.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Platform))
        .WithName("DeletePlatform")
        .Produces<Platform>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}