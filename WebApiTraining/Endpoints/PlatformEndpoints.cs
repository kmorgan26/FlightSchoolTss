using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Entities;
using WebApiTraining.DTOs.Platform;

namespace WebApiTraining.Endpoints;

public static class PlatformEndpoints
{
    public static void MapPlatformEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Platform").WithTags(nameof(Platform));

        group.MapGet("/", async (FstssDataContext db, IMapper mapper) =>
        {
            var platforms = await db.Platforms.ToListAsync();
            return mapper.Map<List<PlatformDto>>(platforms);
        })
        .WithName("GetAllPlatforms")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<PlatformDto>, NotFound>> (int id, FstssDataContext db, IMapper mapper) =>
        {
            var platform = await db.Platforms.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id);

            var result = mapper.Map<PlatformDto>(platform);

            return platform is null ? TypedResults.NotFound() : TypedResults.Ok(result);
                
        })
        .WithName("GetPlatformById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, PlatformDto platformDto, FstssDataContext db, IMapper mapper) =>
        {
            var affected = await db.Platforms
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.IsActive, platformDto.IsActive)
                  .SetProperty(m => m.Name, platformDto.Name)
                  .SetProperty(m => m.MaintainerId, platformDto.MaintainerId)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePlatform")
        .WithOpenApi();

        group.MapPost("/", async (CreatePlatformDto createPlatformDto, FstssDataContext db, IMapper mapper) =>
        {
            var platform = mapper.Map<Platform>(createPlatformDto);
            db.Platforms.Add(platform);
            
            await db.SaveChangesAsync();

            var result = mapper.Map<PlatformDto>(platform);
            return TypedResults.Created($"/api/Platform/{platform.Id}", result);
        })
        .WithName("CreatePlatform")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, FstssDataContext db) =>
        {
            var affected = await db.Platforms
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePlatform")
        .WithOpenApi();
    }
}
