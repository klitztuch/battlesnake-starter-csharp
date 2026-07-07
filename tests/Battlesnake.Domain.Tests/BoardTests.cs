namespace Battlesnake.Domain.Tests;

public class BoardTests
{
    private static readonly SnakeAppearance Appearance =
        new("#ffffff", BattlesnakeHead.Default, BattlesnakeTail.Default);

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(10, 10, true)]
    [InlineData(-1, 0, false)]
    [InlineData(0, 11, false)]
    [InlineData(11, 0, false)]
    public void Contains_ChecksBounds(int x, int y, bool expected)
    {
        var board = new Board(11, 11, [], [], []);

        Assert.Equal(expected, board.Contains(new Coordinate(x, y)));
    }

    [Fact]
    public void IsOccupiedBySnake_DetectsBodySegments()
    {
        var snake = new Snake("id", "name", 100,
            [new Coordinate(1, 1), new Coordinate(1, 2)], 2, "", Appearance);
        var board = new Board(11, 11, [], [snake], []);

        Assert.True(board.IsOccupiedBySnake(new Coordinate(1, 1)));
        Assert.True(board.IsOccupiedBySnake(new Coordinate(1, 2)));
        Assert.False(board.IsOccupiedBySnake(new Coordinate(5, 5)));
    }
}