namespace Battlesnake.Api.Contracts;

/// <summary>Wire DTO for the ruleset.</summary>
public class RulesetDto
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public RulesetSettingsDto Settings { get; set; } = new();
}