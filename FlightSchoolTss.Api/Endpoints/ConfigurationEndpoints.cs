using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Data.DTOs.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class ConfigurationEndpoints
{
    public static void MapConfigurationEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/configuration").WithTags(nameof(Configuration));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var configs = await unitOfWork.Configurations.GetAllAsync();
            return mapper.Map<List<ConfigurationDto>>(configs);
        })
        .WithTags(nameof(Configuration))
        .WithName("GetAllConfigurations")
        .Produces<List<ConfigurationDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.Configurations.GetAsync(id)
                is Configuration model
                    ? Results.Ok(mapper.Map<ConfigurationDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Configuration))
        .WithName("GetConfigurationById")
        .Produces<ConfigurationDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", [AllowAnonymous] async (int id, ConfigurationDto configDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.Configurations.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(configDto, foundModel);

            await unitOfWork.Configurations.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(Configuration))
        .WithName("UpdateConfiguration")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [AllowAnonymous] async (ConfigurationDto configurationDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var config = mapper.Map<Configuration>(configurationDto);
            await unitOfWork.Configurations.AddAsync(config);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/Configuration/{config.Id}", config);
        })
        .AddEndpointFilter<ValidationFilter<ConfigurationDto>>()
        .WithTags(nameof(Configuration))
        .WithName("CreateConfiguration")
        .Produces<Configuration>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.Configurations.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Configuration))
        .WithName("DeleteConfiguration")
        .Produces<Configuration>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}