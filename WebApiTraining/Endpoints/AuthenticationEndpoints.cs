using WebApiTraining.DTOs.Authentication;
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
        .WithTags("Authentication")
        .WithName("Login")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized);
    }
}