using Battlesnake.Domain;

namespace Battlesnake.Application;

/// <summary>
///     The application boundary the API calls into. Orchestrates the four Battlesnake
///     lifecycle events over the pure-domain <see cref="GameState" />.
/// </summary>
public interface ISnakeService
{
    /// <summary>Metadata about this snake (for the info request).</summary>
    SnakeDetails GetDetails();

    /// <summary>Called when a new game begins.</summary>
    void Start(GameState state);

    /// <summary>Decides the move for the current turn.</summary>
    MoveDecision DecideMove(GameState state);

    /// <summary>Called when a game ends.</summary>
    void End(GameState state);
}