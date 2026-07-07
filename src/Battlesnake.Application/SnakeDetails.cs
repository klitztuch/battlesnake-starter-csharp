using Battlesnake.Domain;

namespace Battlesnake.Application;

/// <summary>
///     The metadata describing this Battlesnake (returned to the game engine's info request).
/// </summary>
public sealed record SnakeDetails(
    string ApiVersion,
    string? Author,
    string? Color,
    BattlesnakeHead Head,
    BattlesnakeTail Tail,
    string? Version);