using Microsoft.Extensions.Logging;
using RevrenLove.LetsGetCrappy.Engine;
using RevrenLove.LetsGetCrappy.Engine.Actors;
using RevrenLove.LetsGetCrappy.Engine.Models;

namespace RevrenLove.LetsGetCrappy.Cli;

public class GameRunner
{
    private readonly PlayerFactory _playerFactory;
    private readonly RollHandler _rollHandler;
    private readonly ILogger<GameRunner> _logger;

    public GameRunner(
        PlayerFactory playerFactory,
        RollHandler rollHandler,
        ILogger<GameRunner> logger)
    {
        _playerFactory = playerFactory;
        _rollHandler = rollHandler;
        _logger = logger;
    }

    public void Execute()
    {
        _logger.LogInformation("Let's Get Crappy, Y'all!!! - Program starting...");

        // TODO: Prompt for wallet input
        var player = _playerFactory.CreatePlayer(10000);

        while (true)
        {
            if (!PlayRound(player))
            {
                player = _playerFactory.CreatePlayer(10000);

                _logger.LogInformation("{PlayerName} is up! Play again? Press [Space Bar]", player.Name);
            }
            else
            {
                _logger.LogInformation("{PlayerName} is up, again! Play again? Press [Space Bar]", player.Name);
            }

            if (Console.ReadKey().Key != ConsoleKey.Spacebar)
            {
                break;
            }
        }
    }

    /// <summary>
    /// TODO: This will need to be reworked...
    /// Plays a round with the given `player`
    /// </summary>
    /// <param name="player"></param>
    /// <returns>`True` if `player` will be shooting the next round, `False` otherwise.</returns>
    public bool PlayRound(Player player)
    {
        _logger.LogInformation("{PlayerName} is starting a new round!", player.Name);

        var roll = RollComeOutPhase(player);
        while (!roll.IsPoint)
        {
            roll = RollComeOutPhase(player);
        }

        var pointRoll = roll;
        _logger.LogInformation("We're on {PointRollValue} for the point!", pointRoll.Value);

        roll = RollPointPhase(player);

        while (true)
        {
            if (roll.Value == 7)
            {
                return false;
            }

            if (roll.Value == pointRoll.Value)
            {
                return true;
            }

            roll = RollPointPhase(player);
        }
    }

    public Roll RollComeOutPhase(Player player)
    {
        var roll = _rollHandler.Throw(player);

        // TODO: Show bet results, but put that in the Engine???

        return roll;
    }

    public Roll RollPointPhase(Player player)
    {
        var roll = _rollHandler.Throw(player);

        // TODO: Show bet results, but put that in the Engine???

        return roll;
    }
}
