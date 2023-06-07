using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Data.DTOs.ItemTypes;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class ItemTypeEndpoints
{
    public static void MapItemTypeEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/itemtype").WithTags(nameof(ItemType));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var itemTypes = await unitOfWork.ItemTypes.GetAllAsync();
            return mapper.Map<List<ItemTypeDto>>(itemTypes);
        })
        .WithTags(nameof(ItemType))
        .WithName("GetAllItemTypes")
        .Produces<List<ItemTypeDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.ItemTypes.GetAsync(id)
                is ItemType model
                    ? Results.Ok(mapper.Map<ItemTypeDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(ItemType))
        .WithName("GetItemTypeById")
        .Produces<ItemTypeDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, ItemTypeDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.ItemTypes.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(dto, foundModel);

            await unitOfWork.ItemTypes.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(ItemType))
        .WithName("UpdateItemType")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateItemTypeDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var itemType = mapper.Map<ItemType>(dto);
            await unitOfWork.ItemTypes.AddAsync(itemType);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/ItemType/{itemType.Id}", itemType);
        })
        .AddEndpointFilter<ValidationFilter<CreateItemTypeDto>>()
        .WithTags(nameof(ItemType))
        .WithName("CreateItemType")
        .Produces<ItemType>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.ItemTypes.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(ItemType))
        .WithName("DeleteItemType")
        .Produces<ItemType>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}