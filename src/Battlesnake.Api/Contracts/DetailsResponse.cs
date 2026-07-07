using Battlesnake.Domain;

namespace Battlesnake.Api.Contracts;

/// <summary>Response body of the info request (GET /).</summary>
public class DetailsResponse
{
    public string ApiVersion { get; set; } = "1";
    public string? Author { get; set; }
    public string? Color { get; set; }
    public BattlesnakeHead Head { get; set; } = BattlesnakeHead.Default;
    public BattlesnakeTail Tail { get; set; } = BattlesnakeTail.Default;
    public string? Version { get; set; }
}