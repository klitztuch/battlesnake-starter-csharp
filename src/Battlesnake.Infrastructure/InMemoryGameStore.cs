using System.Collections.Concurrent;
using Battlesnake.Application.Abstractions;

namespace Battlesnake.Infrastructure;

/// <summary>
///     Thread-safe in-memory implementation of <see cref="IGameStore" />. Suitable for a single
///     instance; swap for a distributed store (Redis, a database, …) if you scale out.
/// </summary>
public sealed class InMemoryGameStore : IGameStore
{
    private readonly ConcurrentDictionary<string, byte> _games = new();

    public void Add(string gameId)
    {
        _games.TryAdd(gameId, 0);
    }

    public void Remove(string gameId)
    {
        _games.TryRemove(gameId, out _);
    }

    public int ActiveGameCount => _games.Count;
}