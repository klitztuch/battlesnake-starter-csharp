namespace Battlesnake.Domain;

/// <summary>
///     A position on the 2D grid game board. Coordinates begin at zero, with (0,0)
///     in the bottom-left corner. Value equality makes it usable as a set/lookup key
///     in the move logic.
/// </summary>
public readonly record struct Coordinate(int X, int Y)
{
    /// <summary>
    ///     The neighboring coordinate one step in the given <paramref name="direction" />.
    /// </summary>
    public Coordinate Step(Direction direction)
    {
        return direction switch
        {
            Direction.Up => this with { Y = Y + 1 },
            Direction.Down => this with { Y = Y - 1 },
            Direction.Left => this with { X = X - 1 },
            Direction.Right => this with { X = X + 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}