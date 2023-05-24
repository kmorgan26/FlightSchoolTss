using AutoMapper;
using FluentValidation;
using FlightSchoolTss.Data.Entities;
using FlightSchoolTss.Data.Interfaces;
using FlightSchoolTss.Filters;
using FlightSchoolTss.Api.DTOs.Maintainable;
using Microsoft.AspNetCore.Authorization;

namespace FlightSchoolTss.Endpoints;
public static class MaintainableEndpoints
{
    public static void MapMaintainableEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/itemtypes").WithTags(nameof(Maintainable));

        group.MapGet("/", [AllowAnonymous] async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var maintainables = await unitOfWork.Maintainables.GetAllAsync();
            return mapper.Map<List<MaintainableDto>>(maintainables);
        })
        .WithTags(nameof(Maintainable))
        .WithName("GetAllMaintainables")
        .Produces<List<MaintainableDto>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            return await unitOfWork.Maintainables.GetAsync(id)
                is Maintainable model
                    ? Results.Ok(mapper.Map<MaintainableDto>(model))
                    : Results.NotFound();
        })
        .WithTags(nameof(Maintainable))
        .WithName("GetMaintainableById")
        .Produces<MaintainableDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{id}", async (int id, MaintainableDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var foundModel = await unitOfWork.Maintainables.GetAsync(id);

            if (foundModel is null)
                return Results.NotFound();

            mapper.Map(dto, foundModel);

            await unitOfWork.Maintainables.UpdateAsync(foundModel.Id);
            await unitOfWork.CommitAsync();

            return Results.NoContent();
        })
        .WithTags(nameof(Maintainable))
        .WithName("UpdateMaintainable")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        group.MapPost("/", async (CreateMaintainableDto dto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var maintainable = mapper.Map<Maintainable>(dto);
            await unitOfWork.Maintainables.AddAsync(maintainable);
            await unitOfWork.CommitAsync();

            return Results.Created($"/api/Maintainable/{maintainable.Id}", maintainable);
        })
        .AddEndpointFilter<ValidationFilter<CreateMaintainableDto>>()
        .WithTags(nameof(Maintainable))
        .WithName("CreateMaintainable")
        .Produces<Maintainable>(StatusCodes.Status201Created);

        group.MapDelete("/{id}", async (int id, IUnitOfWork unitOfWork) =>
        {
            var result = await unitOfWork.Maintainables.DeleteAsync(id);
            await unitOfWork.CommitAsync();

            return result == true ? Results.NoContent() : Results.NotFound();
        })
        .WithTags(nameof(Maintainable))
        .WithName("DeleteMaintainable")
        .Produces<Maintainable>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}