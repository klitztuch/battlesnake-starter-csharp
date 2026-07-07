namespace Battlesnake.Api.Contracts;

/// <summary>
///     Deserialized body of the /start, /move and /end requests from the Battlesnake game engine.
/// </summary>
public class GameStatusRequest
{
    public GameDto Game { get; set; } = new();
    public int Turn { get; set; }
    public BoardDto Board { get; set; } = new();
    public SnakeDto You { get; set; } = new();
}