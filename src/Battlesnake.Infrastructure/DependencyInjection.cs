using Battlesnake.Application;
using Battlesnake.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Battlesnake.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    ///     Registers the infrastructure adapters and binds <see cref="SnakeOptions" /> from the
    ///     "Snake" configuration section.
    /// </summary>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IGameStore, InMemoryGameStore>();
        services.Configure<SnakeOptions>(configuration.GetSection(SnakeOptions.SectionName));
        return services;
    }
}