using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RevrenLove.LetsGetCrappy.Cli;
using RevrenLove.LetsGetCrappy.Engine;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddCrappyEngine();
builder.Services.AddSingleton<GameRunner>();

using var host = builder.Build();

ExecuteGameRunner(host.Services);

await host.RunAsync();

static void ExecuteGameRunner(IServiceProvider hostProvider)
{
    using var serviceScope = hostProvider.CreateScope();

    var gameRunner = serviceScope.ServiceProvider.GetRequiredService<GameRunner>();

    gameRunner.Execute();
}