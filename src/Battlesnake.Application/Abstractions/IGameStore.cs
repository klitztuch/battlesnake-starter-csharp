namespace Battlesnake.Application.Abstractions;

/// <summary>
///     Port for keeping track of the games this snake is currently playing, across the
///     /start → /move → /end lifecycle. Implemented by the infrastructure layer.
/// </summary>
public interface IGameStore
{
    /// <summary>The number of games currently in progress.</summary>
    int ActiveGameCount { get; }

    /// <summary>Records that a new game has started.</summary>
    void Add(string gameId);

    /// <summary>Records that a game has ended.</summary>
    void Remove(string gameId);
}