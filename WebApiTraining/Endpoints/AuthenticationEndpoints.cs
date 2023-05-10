using FluentValidation;
using WebApiTraining.DTOs.Authentication;
using WebApiTraining.Filters;
using WebApiTraining.Services;

namespace WebApiTraining.Endpoints;
public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/api/login", async (LoginDto loginDto, IAuthManager authManager) =>
        {
            var response = await authManager.Login(loginDto);

            if (response is null)
            {
                return Results.Unauthorized();
            }

            return Results.Ok(response);

        })
        .AllowAnonymous()
        .WithTags("Authentication")
        .WithName("Login")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized);

        routeBuilder.MapPost("/api/register", async (RegisterUserDto registerUserDto, IAuthManager authManager) =>
        {
            var response = await authManager.Register(registerUserDto);

            if (!response.Any())
                return Results.Ok();
            
            return Results.BadRequest();
        })
        .AddEndpointFilter<ValidationFilter<RegisterUserDto>>()
        .AllowAnonymous()
        .WithTags("Authentication")
        .WithName("Register")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest);
    }
}