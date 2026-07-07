namespace Battlesnake.Domain.Strategies;

/// <summary>
///     Picks a random direction among those that do not immediately kill the snake:
///     it discards moves that run off the board or into any snake body (its own or an
///     opponent's). If no safe move exists the snake is doomed, and a deterministic
///     direction is returned. A simple, testable starting point for real AI.
/// </summary>
public sealed class SafeRandomMoveStrategy : IMoveStrategy
{
    private static readonly Direction[] AllDirections =
        [Direction.Down, Direction.Left, Direction.Right, Direction.Up];

    public Direction DecideMove(GameState state)
    {
        var safeMoves = SafeMoves(state);

        if (safeMoves.Count == 0)
            // No safe move — the snake cannot survive this turn; move deterministically.
            return Direction.Up;

        return safeMoves[Random.Shared.Next(safeMoves.Count)];
    }

    /// <summary>
    ///     The directions from the current head that stay on the board and avoid all snake bodies.
    /// </summary>
    public static IReadOnlyList<Direction> SafeMoves(GameState state)
    {
        var head = state.You.Head;
        var board = state.Board;

        var safeMoves = new List<Direction>(AllDirections.Length);
        foreach (var direction in AllDirections)
        {
            var target = head.Step(direction);
            if (!board.Contains(target))
                continue; // would leave the board

            if (board.IsOccupiedBySnake(target))
                continue; // would collide with a snake body

            safeMoves.Add(direction);
        }

        return safeMoves;
    }
}