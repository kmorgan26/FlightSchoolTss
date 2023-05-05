using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using AutoMapper;
using WebApiTraining.DTOs.Lot;

namespace WebApiTraining.Endpoints;

public static class LotEndpoints
{
    public static void MapLotEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/lot").WithTags(nameof(Lot));

        group.MapGet("/", async (FstssDataContext db, IMapper mapper) =>
        {
            var lots = await db.Lots.ToListAsync();
            return mapper.Map<List<LotDto>>(lots);
        })
        .WithName("GetAllLots")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<LotDto>, NotFound>> (int id, FstssDataContext db, IMapper mapper) =>
        {
            var lot = await db.Lots.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id);

            return lot is null ? TypedResults.NotFound() : TypedResults.Ok(mapper.Map<LotDto>(lot));
        })
        .WithName("GetLotById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, LotDto lotDto, FstssDataContext db) =>
        {
            var affected = await db.Lots
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.PlatformId, lotDto.PlatformId)
                  .SetProperty(m => m.Name, lotDto.Name)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateLot")
        .WithOpenApi();

        group.MapPost("/", async (CreateLotDto createLotDto, FstssDataContext db, IMapper mapper) =>
        {
            var lot = mapper.Map<Lot>(createLotDto);
            db.Lots.Add(lot);

            await db.SaveChangesAsync();
            var result = mapper.Map<LotDto>(lot);
            return TypedResults.Created($"/api/lot/{lot.Id}",result);
        })
        .WithName("CreateLot")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, FstssDataContext db) =>
        {
            var affected = await db.Lots
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteLot")
        .WithOpenApi();
    }
}