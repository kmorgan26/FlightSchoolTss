using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Data.DTOs.HardwareConfiguration;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class HardwareConfigurationEndpoints
{
    public static void MapHardwareConfigurationEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/hardwareconfiguration").WithTags(nameof(HardwareConfiguration));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var configs = await unitOfWork.HardwareConfigurations.GetAllAsync();
            return mapper.Map<List<HardwareConfigurationDto>>(configs);
        })
        .WithTags(nameof(HardwareConfiguration))
        .WithName("GetAllHardwareConfigurations")
        .Produces<List<HardwareConfigurationDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.HardwareConfigurations.GetAsync(id)
                is HardwareConfiguration model
                    ? Results.Ok(mapper.Map<HardwareConfigurationDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(HardwareConfiguration))
        .WithName("GetHardwareConfigurationById")
        .Produces<HardwareConfigurationDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", [AllowAnonymous] async (int id, HardwareConfigurationDto configDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.HardwareConfigurations.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(configDto, foundModel);

            await unitOfWork.HardwareConfigurations.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(HardwareConfiguration))
        .WithName("UpdateHardwareConfiguration")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [AllowAnonymous] async (HardwareConfigurationDto hardwareConfigurationDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var config = mapper.Map<HardwareConfiguration>(hardwareConfigurationDto);
            await unitOfWork.HardwareConfigurations.AddAsync(config);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/HardwareConfiguration/{config.Id}", config);
        })
        .AddEndpointFilter<ValidationFilter<HardwareConfigurationDto>>()
        .WithTags(nameof(HardwareConfiguration))
        .WithName("CreateHardwareConfiguration")
        .Produces<HardwareConfiguration>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.HardwareConfigurations.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(HardwareConfiguration))
        .WithName("DeleteHardwareConfiguration")
        .Produces<HardwareConfiguration>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}