namespace Battlesnake.Domain;

/// <summary>
///     The game board: a 2D grid oriented with (0,0) in the bottom-left, the Y-axis
///     positive upward and the X-axis positive to the right.
/// </summary>
public sealed record Board(
    int Width,
    int Height,
    IReadOnlyList<Coordinate> Food,
    IReadOnlyList<Snake> Snakes,
    IReadOnlyList<Coordinate> Hazards)
{
    /// <summary>
    ///     Whether the coordinate lies inside the board bounds.
    /// </summary>
    public bool Contains(Coordinate coordinate)
    {
        return coordinate.X >= 0 && coordinate.X < Width &&
               coordinate.Y >= 0 && coordinate.Y < Height;
    }

    /// <summary>
    ///     Whether the coordinate is currently covered by any snake's body
    ///     (including your own).
    /// </summary>
    public bool IsOccupiedBySnake(Coordinate coordinate)
    {
        foreach (var snake in Snakes)
        foreach (var segment in snake.Body)
            if (segment == coordinate)
                return true;

        return false;
    }
}