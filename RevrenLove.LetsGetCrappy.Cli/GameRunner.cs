using RevrenLove.LetsGetCrappy.Engine.Actors;

namespace RevrenLove.LetsGetCrappy.Cli;

public class GameRunner
{
    private readonly ShooterFactory _shooterFactory;

    public GameRunner(ShooterFactory shooterFactory)
    {
        _shooterFactory = shooterFactory;
    }

    public void Execute()
    {
        var shooter = _shooterFactory.CreateShooter();

        var roll = shooter.Throw();

        Console.WriteLine(roll.Value);
        Console.WriteLine(roll.Name);
    }
}
