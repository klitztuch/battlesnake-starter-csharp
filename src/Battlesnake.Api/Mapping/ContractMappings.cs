using Battlesnake.Api.Contracts;
using Battlesnake.Application;
using Battlesnake.Domain;

namespace Battlesnake.Api.Mapping;

/// <summary>
///     Translates between the Battlesnake wire contracts and the pure-domain model, keeping the
///     domain free of any JSON/HTTP concerns.
/// </summary>
public static class ContractMappings
{
    public static GameState ToDomain(this GameStatusRequest request)
    {
        return new GameState(
            request.Game.ToDomain(),
            request.Turn,
            request.Board.ToDomain(),
            request.You.ToDomain());
    }

    public static MoveResponse ToResponse(this MoveDecision decision)
    {
        return new MoveResponse
        {
            Move = decision.Move,
            Shout = decision.Shout
        };
    }

    public static DetailsResponse ToResponse(this SnakeDetails details)
    {
        return new DetailsResponse
        {
            ApiVersion = details.ApiVersion,
            Author = details.Author,
            Color = details.Color,
            Head = details.Head,
            Tail = details.Tail,
            Version = details.Version
        };
    }

    private static Game ToDomain(this GameDto game)
    {
        return new Game(
            game.Id,
            game.Ruleset.ToDomain(),
            game.Map,
            game.Timeout,
            game.Source);
    }

    private static Ruleset ToDomain(this RulesetDto ruleset)
    {
        return new Ruleset(
            ruleset.Name,
            ruleset.Version,
            ruleset.Settings.ToDomain());
    }

    private static RulesetSettings ToDomain(this RulesetSettingsDto settings)
    {
        return new RulesetSettings(
            settings.FoodSpawnChance,
            settings.MinimumFood,
            settings.HazardDamagePerTurn,
            new RoyaleModeSettings(settings.Royale.ShrinkEveryNTurns),
            new SquadModeSettings(
                settings.Squad.AllowBodyCollisions,
                settings.Squad.SharedElimination,
                settings.Squad.SharedHealth,
                settings.Squad.SharedLength));
    }

    private static Board ToDomain(this BoardDto board)
    {
        return new Board(
            board.Width,
            board.Height,
            board.Food.ToCoordinates(),
            board.Snakes.Select(snake => snake.ToDomain()).ToList(),
            board.Hazards.ToCoordinates());
    }

    private static Snake ToDomain(this SnakeDto snake)
    {
        return new Snake(
            snake.Id,
            snake.Name,
            snake.Health,
            snake.Body.ToCoordinates(),
            snake.Length,
            snake.Shout,
            new SnakeAppearance(
                snake.Customizations.Color,
                snake.Customizations.Head,
                snake.Customizations.Tail));
    }

    private static Coordinate ToDomain(this CoordinateDto coordinate)
    {
        return new Coordinate(coordinate.X, coordinate.Y);
    }

    private static IReadOnlyList<Coordinate> ToCoordinates(
        this IEnumerable<CoordinateDto> coordinates)
    {
        return coordinates.Select(coordinate => coordinate.ToDomain()).ToList();
    }
}