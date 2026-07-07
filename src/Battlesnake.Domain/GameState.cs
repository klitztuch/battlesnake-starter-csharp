namespace Battlesnake.Domain;

/// <summary>
///     The full state of a single turn, as handed to a <see cref="Strategies.IMoveStrategy" />.
///     This is the pure-domain equivalent of the Battlesnake move request.
/// </summary>
public sealed record GameState(Game Game, int Turn, Board Board, Snake You);