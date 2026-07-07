using Battlesnake.Domain;

namespace Battlesnake.Application;

/// <summary>
///     Configurable appearance and metadata of the snake. Bound from the "Snake" configuration
///     section by the infrastructure layer; the defaults reproduce the original starter.
/// </summary>
public sealed class SnakeOptions
{
    public const string SectionName = "Snake";

    public string ApiVersion { get; set; } = "1";
    public string? Author { get; set; } = "";
    public string Color { get; set; } = "#FFFFFF";
    public BattlesnakeHead Head { get; set; } = BattlesnakeHead.Horse;
    public BattlesnakeTail Tail { get; set; } = BattlesnakeTail.Default;
    public string? Version { get; set; }
}