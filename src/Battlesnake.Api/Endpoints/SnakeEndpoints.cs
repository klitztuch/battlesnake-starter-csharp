using Battlesnake.Api.Contracts;
using Battlesnake.Api.Mapping;
using Battlesnake.Application;

namespace Battlesnake.Api.Endpoints;

/// <summary>
///     Maps the four endpoints the Battlesnake game engine calls. Each one maps the wire contract
///     to the domain, delegates to <see cref="ISnakeService" />, and maps the result back.
/// </summary>
public static class SnakeEndpoints
{
    public static WebApplication MapSnakeEndpoints(this WebApplication app)
    {
        // Info request — polled periodically for snake metadata.
        app.MapGet("/", (ISnakeService snakeService) =>
            snakeService.GetDetails().ToResponse());

        // A new game has started; the engine ignores the response.
        app.MapPost("/start", (ISnakeService snakeService, GameStatusRequest request) =>
        {
            snakeService.Start(request.ToDomain());
            return Results.Ok();
        });

        // The core loop — called every turn to decide the move.
        app.MapPost("/move", (ISnakeService snakeService, GameStatusRequest request) =>
            snakeService.DecideMove(request.ToDomain()).ToResponse());

        // The game has ended; the engine ignores the response.
        app.MapPost("/end", (ISnakeService snakeService, GameStatusRequest request) =>
        {
            snakeService.End(request.ToDomain());
            return Results.Ok();
        });

        return app;
    }
}