namespace Battlesnake.Domain;

/// <summary>
///     A Battlesnake on the board.
/// </summary>
public sealed record Snake(
    string Id,
    string Name,
    int Health,
    IReadOnlyList<Coordinate> Body,
    int Length,
    string Shout,
    SnakeAppearance Appearance)
{
    /// <summary>
    ///     The head of the snake, equivalent to the first element of <see cref="Body" />.
    /// </summary>
    public Coordinate Head => Body.Count > 0 ? Body[0] : default;
}