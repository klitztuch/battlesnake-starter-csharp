using Battlesnake.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Battlesnake.Application;

public static class DependencyInjection
{
    /// <summary>
    ///     Registers the application services (and the domain services they build on).
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDomain();
        services.AddSingleton<ISnakeService, SnakeService>();
        return services;
    }
}