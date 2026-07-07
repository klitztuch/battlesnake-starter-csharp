using Battlesnake.Application.Abstractions;
using Battlesnake.Domain;
using Battlesnake.Domain.Strategies;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Battlesnake.Application.Tests;

public class SnakeServiceTests
{
    private static readonly SnakeAppearance Appearance =
        new("#ffffff", BattlesnakeHead.Default, BattlesnakeTail.Default);

    private static SnakeService CreateService(
        SnakeOptions? options = null, IGameStore? store = null)
    {
        return new SnakeService(
            new SafeRandomMoveStrategy(),
            store ?? new FakeGameStore(),
            Options.Create(options ?? new SnakeOptions()),
            NullLogger<SnakeService>.Instance);
    }

    private static GameState SampleState()
    {
        var you = new Snake("me", "me", 100, [new Coordinate(5, 5)], 1, "", Appearance);
        var board = new Board(11, 11, [], [you], []);
        var game = new Game("g", new Ruleset("standard", "v1",
                new RulesetSettings(0, 0, 0, new RoyaleModeSettings(0),
                    new SquadModeSettings(false, false, false, false))),
            "standard", 500, "custom");
        return new GameState(game, 0, board, you);
    }

    [Fact]
    public void DecideMove_ReturnsValidDirection()
    {
        var service = CreateService();

        var decision = service.DecideMove(SampleState());

        Assert.Contains(decision.Move,
            new[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right });
    }

    [Fact]
    public void StartThenEnd_TracksActiveGames()
    {
        var store = new FakeGameStore();
        var service = CreateService(store: store);
        var state = SampleState();

        service.Start(state);
        Assert.Equal(1, store.ActiveGameCount);

        service.End(state);
        Assert.Equal(0, store.ActiveGameCount);
    }

    [Fact]
    public void GetDetails_ReflectsConfiguredAppearance()
    {
        var options = new SnakeOptions
        {
            Author = "tester",
            Color = "#123456",
            Head = BattlesnakeHead.Bee,
            Tail = BattlesnakeTail.Bolt,
            Version = "1.0.0"
        };
        var service = CreateService(options);

        var details = service.GetDetails();

        Assert.Equal("tester", details.Author);
        Assert.Equal("#123456", details.Color);
        Assert.Equal(BattlesnakeHead.Bee, details.Head);
        Assert.Equal(BattlesnakeTail.Bolt, details.Tail);
        Assert.Equal("1.0.0", details.Version);
    }

    private sealed class FakeGameStore : IGameStore
    {
        public int ActiveGameCount { get; private set; }

        public void Add(string gameId)
        {
            ActiveGameCount++;
        }

        public void Remove(string gameId)
        {
            ActiveGameCount--;
        }
    }
}