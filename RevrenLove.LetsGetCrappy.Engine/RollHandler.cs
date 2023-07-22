using Microsoft.Extensions.Logging;
using RevrenLove.LetsGetCrappy.Engine.Actors;
using RevrenLove.LetsGetCrappy.Engine.Models;

namespace RevrenLove.LetsGetCrappy.Engine;

// TODO: Move this class, probably...
public class RollHandler
{
    private readonly Random _random;
    private readonly ILogger<RollHandler> _logger;

    public RollHandler(
        Random random,
        ILogger<RollHandler> logger)
    {
        _random = random;
        _logger = logger;
    }

    public Roll Throw(Player player)
    {
        var a = Die.GetDyeByValue(_random.Next(1, 7));
        var b = Die.GetDyeByValue(_random.Next(1, 7));

        var roll = RollFactory.CreateRoll(a, b);

        _logger.LogInformation(
            "{ShooterName} rolled {DieA} {DieB} - {RollName}",
            player.Name,
            roll.Dice[0].Value,
            roll.Dice[1].Value,
            roll.Name);

        return roll;
    }
}
