using AutoMapper;
using FluentValidation;
using WebApiTraining.Data.Entities;
using WebApiTraining.Data.Interfaces;
using WebApiTraining.DTOs.Lot;
using WebApiTraining.DTOs.Maintainer;
using WebApiTraining.DTOs.ManModule;
using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.Endpoints;
public static class LotEndpoints
{
    public static void MapLotEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/lot").WithTags(nameof(Lot));

        group.MapGet("/", async (ILotRepository repo, IMapper mapper) =>
        {
            var lots = await repo.GetAllAsync();
            return mapper.Map<List<LotDto>>(lots);
        })
        .WithTags(nameof(Lot))
        .WithName("GetAllLots")
        .Produces<List<LotDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, ILotRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is Lot model
                    ? Results.Ok(mapper.Map<LotDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Lot))
        .WithName("GetLotById")
        .Produces<LotDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, LotDto lotDto, ILotRepository repo, IMapper mapper) =>
        {
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(lotDto, foundModel);

            await repo.UpdateAsync(foundModel.Id);
            return Results.NoContent();
        })
        .WithTags(nameof(Lot))
        .WithName("UpdateLot")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapGet("/GetManModulesByLotId/{id}", async (int id, ILotRepository repo, IMapper mapper) =>
        {
            return await repo.GetLotsWithManModuleDetailsByIdAsync(id)
                is List<Lot> model
                    ? Results.Ok(mapper.Map<List<LotDetailsDto>>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Lot))
        .WithName("GetManModulesByLotId")
        .Produces<LotDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent);



        group.MapPost("/", async (CreateLotDto createLotDto, ILotRepository repo, IMapper mapper, IValidator<CreateLotDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(createLotDto);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.ToDictionary());

            var lot = mapper.Map<Lot>(createLotDto);
            await repo.AddAsync(lot);
            return Results.Created($"/api/Lot/{lot.Id}", lot);
        })
        .WithTags(nameof(Lot))
        .WithName("CreateLot")
        .Produces<Lot>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, ILotRepository repo) =>
        {
            return await repo.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Lot))
        .WithName("DeleteLot")
        .Produces<Lot>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}