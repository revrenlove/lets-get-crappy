using RevrenLove.LetsGetCrappy.Engine.Actors;
using RevrenLove.LetsGetCrappy.Engine.Models;

namespace RevrenLove.LetsGetCrappy.Cli;

public class GameRunner
{
    private readonly ShooterFactory _shooterFactory;
    private readonly RandomNameGenerator _randomNameGenerator;

    public GameRunner(
        ShooterFactory shooterFactory,
        RandomNameGenerator randomNameGenerator)
    {
        _shooterFactory = shooterFactory;
        _randomNameGenerator = randomNameGenerator;
    }

    public void Execute()
    {
        Console.WriteLine("Let's Get Crappy, Y'all!!!");

        var shooterName = _randomNameGenerator.Generate();
        var shooter = _shooterFactory.CreateShooter(shooterName);

        while (true)
        {


            if (!PlayRound(shooter))
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine();

                shooterName = _randomNameGenerator.Generate(shooterName);
                shooter = _shooterFactory.CreateShooter(shooterName);

                Console.WriteLine($"{shooterName} is up! Play again? Press [Space Bar]");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine($"{shooterName} is up, again! Play again? Press [Space Bar]");
            }

            Console.WriteLine();
            Console.WriteLine("//////////////////////////////////////////////////////////////");

            if (Console.ReadKey().Key != ConsoleKey.Spacebar)
            {
                break;
            }
        }
    }

    public static bool PlayRound(Shooter shooter)
    {
        Console.WriteLine();
        Console.WriteLine("=========================================================");
        Console.WriteLine($"{shooter.Name} is starting a new round!");
        Console.WriteLine("=========================================================");
        Console.WriteLine();
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("Here comes the come out...");
        Console.WriteLine("---------------------------------------------------------");

        var roll = RollComeOut(shooter);
        while (!roll.IsPoint)
        {
            Console.WriteLine("No point yet! Here we roll again!");

            roll = RollComeOut(shooter);
        }

        var pointRoll = roll;
        var pointHasBeenMade = false;

        Console.WriteLine();
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine($"We're on {pointRoll.Value} for the point!");
        Console.WriteLine("---------------------------------------------------------");

        roll = RollPoint(shooter);
        while (roll.Value != 7)
        {
            // TODO: Account for bets???
            if (roll.Value == pointRoll.Value)
            {
                if (!pointHasBeenMade)
                {
                    Console.WriteLine($" - {shooter.Name} rolled the point!");
                }

                pointHasBeenMade = true;
            }

            roll = RollPoint(shooter);
        }

        return pointHasBeenMade;
    }

    public static Roll RollComeOut(Shooter shooter)
    {
        var roll = shooter.Throw();

        Console.WriteLine();
        Console.WriteLine($"{roll.Dice[0].Value} {roll.Dice[1].Value} ({roll.Name})");
        // TODO: Uncomment this when it's actually filled out...
        // Console.WriteLine(roll.FunName);

        // TODO: Show bet results, but put that in the Engine???

        return roll;
    }

    public static Roll RollPoint(Shooter shooter)
    {
        var roll = shooter.Throw();

        Console.WriteLine();
        Console.WriteLine($"{roll.Dice[0].Value} {roll.Dice[1].Value} ({roll.Name})");
        // TODO: Uncomment this when it's actually filled out...
        // Console.WriteLine(roll.FunName);

        // TODO: Show bet results, but put that in the Engine???

        return roll;
    }
}
