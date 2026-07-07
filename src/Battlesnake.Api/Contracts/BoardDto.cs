namespace Battlesnake.Api.Contracts;

/// <summary>Wire DTO for the game board.</summary>
public class BoardDto
{
    public int Height { get; set; }
    public int Width { get; set; }
    public IEnumerable<CoordinateDto> Food { get; set; } = [];
    public IEnumerable<SnakeDto> Snakes { get; set; } = [];
    public IEnumerable<CoordinateDto> Hazards { get; set; } = [];
}