namespace Battlesnake.Domain;

/// <summary>
///     A move direction on the board. The board has (0,0) in the bottom-left,
///     with the Y-axis positive upward and the X-axis positive to the right.
/// </summary>
public enum Direction
{
    Down,
    Left,
    Right,
    Up
}

public static class DirectionExtensions
{
    /// <summary>
    ///     The direction pointing the opposite way (a snake can never move into its own neck).
    /// </summary>
    public static Direction Opposite(this Direction direction)
    {
        return direction switch
        {
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}