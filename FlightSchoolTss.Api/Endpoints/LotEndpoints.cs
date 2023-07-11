using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Data.DTOs.Lot;
using FlightSchoolTss.Filters;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class LotEndpoints
{
    public static void MapLotEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/lot").WithTags(nameof(Lot));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var lots = await unitOfWork.Lots.GetAllAsync();
            return mapper.Map<List<LotDto>>(lots);
        })
        .WithTags(nameof(Lot))
        .WithName("GetAllLots")
        .Produces<List<LotDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.Lots.GetAsync(id)
                is Lot model
                    ? Results.Ok(mapper.Map<LotDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Lot))
        .WithName("GetLotById")
        .Produces<LotDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", [AllowAnonymous] async (int id, LotDto lotDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.Lots.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(lotDto, foundModel);

            await unitOfWork.Lots.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(Lot))
        .WithName("UpdateLot")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/GetManModulesByLotId/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.Lots.GetLotsWithManModuleDetailsByIdAsync(id)
                is List<Lot> model
                    ? Results.Ok(mapper.Map<List<LotDetailsDto>>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Lot))
        .WithName("GetManModulesByLotId")
        .Produces<LotDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", [AllowAnonymous] async (LotDto createLotDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var lot = mapper.Map<Lot>(createLotDto);
            await unitOfWork.Lots.AddAsync(lot);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/Lot/{lot.Id}", lot);
        })
        .AddEndpointFilter<ValidationFilter<LotDto>>()
        .WithTags(nameof(Lot))
        .WithName("CreateLot")
        .Produces<Lot>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", [AllowAnonymous] async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.Lots.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Lot))
        .WithName("DeleteLot")
        .Produces<Lot>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}