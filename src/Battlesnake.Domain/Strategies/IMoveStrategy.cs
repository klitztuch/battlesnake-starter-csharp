namespace Battlesnake.Domain.Strategies;

/// <summary>
///     The core decision of a Battlesnake: given the current turn's <see cref="GameState" />,
///     choose which direction to move. This is where the snake AI lives — implement a new
///     strategy and register it in <see cref="DependencyInjection.AddDomain" /> to change behaviour.
/// </summary>
public interface IMoveStrategy
{
    Direction DecideMove(GameState state);
}