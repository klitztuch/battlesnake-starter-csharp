namespace Battlesnake.Api.Contracts;

/// <summary>Wire DTO for the game metadata.</summary>
public class GameDto
{
    public string Id { get; set; } = string.Empty;
    public RulesetDto Ruleset { get; set; } = new();
    public string Map { get; set; } = string.Empty;
    public int Timeout { get; set; }
    public string Source { get; set; } = string.Empty;
}