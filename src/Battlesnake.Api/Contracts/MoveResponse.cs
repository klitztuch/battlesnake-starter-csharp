using Battlesnake.Domain;

namespace Battlesnake.Api.Contracts;

/// <summary>Response body of the /move request.</summary>
public class MoveResponse
{
    /// <summary>The chosen move for this turn. Serialized as "up", "down", "left" or "right".</summary>
    public Direction Move { get; set; } = Direction.Up;

    /// <summary>An optional message sent to all other Battlesnakes on the next turn (max 256 chars).</summary>
    public string? Shout { get; set; }
}