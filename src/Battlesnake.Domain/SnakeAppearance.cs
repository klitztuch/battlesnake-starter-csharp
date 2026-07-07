namespace Battlesnake.Domain;

/// <summary>
///     The cosmetic customizations of a Battlesnake (how it is drawn on the board).
/// </summary>
public sealed record SnakeAppearance(string Color, BattlesnakeHead Head, BattlesnakeTail Tail);