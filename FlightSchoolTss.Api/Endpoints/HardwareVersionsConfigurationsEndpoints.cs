using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Api.DTOs.HardwareVersionConfiguration;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class HardwareVersionsConfigurationsEndpoints
{
    public static void MapHardwareVersionsConfigurationsEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/hardwareversionconfiguration").WithTags(nameof(HardwareVersionsConfigurations));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var versionsConfigs = await unitOfWork.HardwareVersionsConfigurations.GetAllAsync();
            return mapper.Map<List<HardwareVersionsConfigurationsDto>>(versionsConfigs);
        })
        .WithTags(nameof(HardwareVersionsConfigurations))
        .WithName("GetAllHardwareVersionConfigurations")
        .Produces<List<HardwareVersionsConfigurationsDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.HardwareVersionsConfigurations.GetAsync(id)
                is HardwareVersionsConfigurations model
                    ? Results.Ok(mapper.Map<HardwareVersionsConfigurationsDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(HardwareVersionsConfigurations))
        .WithName("GetHardwareVersionConfigurationById")
        .Produces<HardwareVersionsConfigurationsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, HardwareVersionsConfigurationsDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.HardwareVersionsConfigurations.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(dto, foundModel);

            await unitOfWork.HardwareVersionsConfigurations.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(HardwareVersionsConfigurations))
        .WithName("UpdateHardwareVersionConfiguration")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateHardwareVersionConfigurationDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var hwVersionConfig = mapper.Map<HardwareVersionsConfigurations>(dto);
            await unitOfWork.HardwareVersionsConfigurations.AddAsync(hwVersionConfig);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/hardwareversionconfiguration/{hwVersionConfig.Id}", hwVersionConfig);
        })
        .AddEndpointFilter<ValidationFilter<CreateHardwareVersionConfigurationDto>>()
        .WithTags(nameof(HardwareVersionsConfigurations))
        .WithName("CreateHardwareVersionConfiguration")
        .Produces<HardwareVersionsConfigurations>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.HardwareVersionsConfigurations.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(HardwareVersionsConfigurations))
        .WithName("DeleteHardwareVersionConfiguration")
        .Produces<HardwareVersionsConfigurations>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}