using Battlesnake.Domain.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace Battlesnake.Domain;

public static class DependencyInjection
{
    /// <summary>
    ///     Registers the domain services. Swap the <see cref="IMoveStrategy" /> registration
    ///     here to change how the snake decides its moves.
    /// </summary>
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IMoveStrategy, SafeRandomMoveStrategy>();
        return services;
    }
}