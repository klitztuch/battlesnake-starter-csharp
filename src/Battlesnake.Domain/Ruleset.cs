namespace Battlesnake.Domain;

/// <summary>
///     Information about the ruleset being used to run the current game.
/// </summary>
public sealed record Ruleset(string Name, string Version, RulesetSettings Settings);