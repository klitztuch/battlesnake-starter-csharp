namespace Battlesnake.Domain.Tests;

public class CoordinateTests
{
    [Theory]
    [InlineData(Direction.Up, 2, 3)]
    [InlineData(Direction.Down, 2, 1)]
    [InlineData(Direction.Left, 1, 2)]
    [InlineData(Direction.Right, 3, 2)]
    public void Step_MovesInExpectedDirection(Direction direction, int expectedX, int expectedY)
    {
        var start = new Coordinate(2, 2);

        var result = start.Step(direction);

        Assert.Equal(new Coordinate(expectedX, expectedY), result);
    }
}