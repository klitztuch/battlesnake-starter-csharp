namespace Battlesnake.Api.Contracts;

/// <summary>Wire DTO for the ruleset settings.</summary>
public class RulesetSettingsDto
{
    public int FoodSpawnChance { get; set; }
    public int MinimumFood { get; set; }
    public int HazardDamagePerTurn { get; set; }
    public RoyaleDto Royale { get; set; } = new();
    public SquadDto Squad { get; set; } = new();

    public class RoyaleDto
    {
        public int ShrinkEveryNTurns { get; set; }
    }

    public class SquadDto
    {
        public bool AllowBodyCollisions { get; set; }
        public bool SharedElimination { get; set; }
        public bool SharedHealth { get; set; }
        public bool SharedLength { get; set; }
    }
}