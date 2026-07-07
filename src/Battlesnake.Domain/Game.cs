namespace Battlesnake.Domain;

/// <summary>
///     Metadata describing the game being played.
/// </summary>
public sealed record Game(
    string Id,
    Ruleset Ruleset,
    string Map,
    int Timeout,
    string Source);