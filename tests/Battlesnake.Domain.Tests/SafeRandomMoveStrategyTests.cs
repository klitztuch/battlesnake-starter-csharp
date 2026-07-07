using Battlesnake.Domain.Strategies;

namespace Battlesnake.Domain.Tests;

public class SafeRandomMoveStrategyTests
{
    private static readonly SnakeAppearance Appearance =
        new("#ffffff", BattlesnakeHead.Default, BattlesnakeTail.Default);

    private static GameState StateWith(Snake you, Board board)
    {
        var game = new Game("g", new Ruleset("standard", "v1",
                new RulesetSettings(0, 0, 0, new RoyaleModeSettings(0),
                    new SquadModeSettings(false, false, false, false))),
            "standard", 500, "custom");
        return new GameState(game, 0, board, you);
    }

    [Fact]
    public void DecideMove_InBottomLeftCorner_NeverMovesOffBoard()
    {
        // Head at (0,0): only Up and Right keep the snake on the board.
        var you = new Snake("me", "me", 100, [new Coordinate(0, 0)], 1, "", Appearance);
        var board = new Board(11, 11, [], [you], []);
        var state = StateWith(you, board);
        var strategy = new SafeRandomMoveStrategy();

        for (var i = 0; i < 100; i++)
        {
            var move = strategy.DecideMove(state);
            Assert.Contains(move, new[] { Direction.Up, Direction.Right });
        }
    }

    [Fact]
    public void SafeMoves_ExcludesOwnBodyButKeepsFreeDirections()
    {
        // Head at (1,1); body continues up through (1,2)-(1,3). Moving Up hits the body.
        var you = new Snake("me", "me", 100,
            [new Coordinate(1, 1), new Coordinate(1, 2), new Coordinate(1, 3)], 3, "", Appearance);
        var board = new Board(11, 11, [], [you], []);
        var state = StateWith(you, board);

        var safe = SafeRandomMoveStrategy.SafeMoves(state);

        Assert.DoesNotContain(Direction.Up, safe);
        Assert.Contains(Direction.Down, safe);
        Assert.Contains(Direction.Left, safe);
        Assert.Contains(Direction.Right, safe);
    }
}