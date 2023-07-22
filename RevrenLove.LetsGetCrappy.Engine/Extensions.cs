using Microsoft.Extensions.DependencyInjection;
using RevrenLove.LetsGetCrappy.Engine.Actors;
using RevrenLove.LetsGetCrappy.Engine.Models;

namespace RevrenLove.LetsGetCrappy.Engine;

public static class Extensions
{
    // TODO: Figure out how we want to register the logger...
    public static IServiceCollection AddCrappyEngine(this IServiceCollection services)
    {
        services
            .AddScoped<PlayerFactory>()
            .AddScoped<RollFactory>()
            .AddScoped<RollHandler>()
            .AddScoped<RandomNameGenerator>()
            .AddScoped<Random>();

        return services;
    }
}
