using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Data.DTOs.ConfigurationItem;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class ConfigurationItemEndpoints
{
    public static void MapConfigurationItemEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/configurationitem").WithTags(nameof(ConfigurationItem));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var configitems = await unitOfWork.ConfigurationItems.GetAllAsync();
            return mapper.Map<List<ConfigurationItemDto>>(configitems);
        })
        .WithTags(nameof(ConfigurationItem))
        .WithName("GetAllConfigurationItems")
        .Produces<List<ConfigurationItemDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.ConfigurationItems.GetAsync(id)
                is ConfigurationItem model
                    ? Results.Ok(mapper.Map<ConfigurationItemDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(ConfigurationItem))
        .WithName("GetConfigurationItemById")
        .Produces<ConfigurationItemDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, ConfigurationItemDto configItemDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.ConfigurationItems.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(configItemDto, foundModel);

            await unitOfWork.ConfigurationItems.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(ConfigurationItem))
        .WithName("UpdateConfigurationItem")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateConfigurationItemDto createConfigurationItemDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var configItem = mapper.Map<ConfigurationItem>(createConfigurationItemDto);
            await unitOfWork.ConfigurationItems.AddAsync(configItem);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/ConfigurationItem/{configItem.Id}", configItem);
        })
        .AddEndpointFilter<ValidationFilter<CreateConfigurationItemDto>>()
        .WithTags(nameof(ConfigurationItem))
        .WithName("CreateConfigurationItem")
        .Produces<ConfigurationItem>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.ConfigurationItems.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(ConfigurationItem))
        .WithName("DeleteConfigurationItem")
        .Produces<ConfigurationItem>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}