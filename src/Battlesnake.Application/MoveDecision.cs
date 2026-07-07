using Battlesnake.Domain;

namespace Battlesnake.Application;

/// <summary>
///     The outcome of a move decision: the chosen direction and an optional shout.
/// </summary>
public sealed record MoveDecision(Direction Move, string? Shout);