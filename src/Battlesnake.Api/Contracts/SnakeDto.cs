using Battlesnake.Domain;

namespace Battlesnake.Api.Contracts;

/// <summary>Wire DTO for a Battlesnake, matching the Battlesnake API JSON.</summary>
public class SnakeDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Health { get; set; }
    public IEnumerable<CoordinateDto> Body { get; set; } = [];
    public CoordinateDto Head { get; set; } = new();
    public int Length { get; set; }
    public string Shout { get; set; } = string.Empty;
    public string Latency { get; set; } = string.Empty;
    public string Squad { get; set; } = string.Empty;
    public CustomizationsDto Customizations { get; set; } = new();

    public class CustomizationsDto
    {
        public string Color { get; set; } = string.Empty;
        public BattlesnakeHead Head { get; set; } = BattlesnakeHead.Default;
        public BattlesnakeTail Tail { get; set; } = BattlesnakeTail.Default;
    }
}