namespace Battlesnake.Domain;

/// <summary>
///     Specific settings controlling how the rules of the current game are applied.
/// </summary>
public sealed record RulesetSettings(
    int FoodSpawnChance,
    int MinimumFood,
    int HazardDamagePerTurn,
    RoyaleModeSettings Royale,
    SquadModeSettings Squad);

/// <summary>
///     Royale-mode specific settings.
/// </summary>
public sealed record RoyaleModeSettings(int ShrinkEveryNTurns);

/// <summary>
///     Squad-mode specific settings.
/// </summary>
public sealed record SquadModeSettings(
    bool AllowBodyCollisions,
    bool SharedElimination,
    bool SharedHealth,
    bool SharedLength);