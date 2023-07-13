using Microsoft.Extensions.DependencyInjection;
using RevrenLove.LetsGetCrappy.Engine.Actors;

namespace RevrenLove.LetsGetCrappy.Engine;

public static class Extensions
{
    public static IServiceCollection AddCrappyEngine(this IServiceCollection services)
    {
        services.AddScoped<ShooterFactory>();
        services.AddScoped<Random>();

        return services;
    }
}
