using Battlesnake.Application.Abstractions;
using Battlesnake.Domain;
using Battlesnake.Domain.Strategies;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Battlesnake.Application;

/// <summary>
///     Default <see cref="ISnakeService" /> implementation: delegates the move decision to the
///     configured <see cref="IMoveStrategy" />, tracks games via <see cref="IGameStore" /> and
///     exposes the configured appearance.
/// </summary>
public sealed class SnakeService(
    IMoveStrategy moveStrategy,
    IGameStore gameStore,
    IOptions<SnakeOptions> options,
    ILogger<SnakeService> logger)
    : ISnakeService
{
    private readonly SnakeOptions _options = options.Value;

    public SnakeDetails GetDetails()
    {
        return new SnakeDetails(
            _options.ApiVersion,
            _options.Author,
            _options.Color,
            _options.Head,
            _options.Tail,
            _options.Version);
    }

    public void Start(GameState state)
    {
        gameStore.Add(state.Game.Id);
        logger.LogInformation("Game {GameId} started.", state.Game.Id);
    }

    public MoveDecision DecideMove(GameState state)
    {
        var move = moveStrategy.DecideMove(state);
        logger.LogInformation(
            "Game {GameId} turn {Turn}: moving {Move}.", state.Game.Id, state.Turn, move);
        return new MoveDecision(move, "I am moving!");
    }

    public void End(GameState state)
    {
        gameStore.Remove(state.Game.Id);
        logger.LogInformation("Game {GameId} ended.", state.Game.Id);
    }
}