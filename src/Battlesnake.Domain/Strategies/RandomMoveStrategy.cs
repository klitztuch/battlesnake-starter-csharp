namespace Battlesnake.Domain.Strategies;

/// <summary>
///     Picks a purely random direction, ignoring the board. This mirrors the behavior of the
///     original starter and is kept as a trivial baseline; <see cref="SafeRandomMoveStrategy" />
///     is the registered default.
/// </summary>
public sealed class RandomMoveStrategy : IMoveStrategy
{
    private static readonly Direction[] AllDirections =
        [Direction.Down, Direction.Left, Direction.Right, Direction.Up];

    public Direction DecideMove(GameState state)
    {
        return AllDirections[Random.Shared.Next(AllDirections.Length)];
    }
}