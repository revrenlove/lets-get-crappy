using RevrenLove.LetsGetCrappy.Engine.Models;

namespace RevrenLove.LetsGetCrappy.Engine.Actors;

public class Shooter
{
    private readonly Random _random;

    internal Shooter(Random random, string name)
    {
        _random = random;
        Name = name;
    }

    public string Name { get; }

    public Roll Throw()
    {
        var a = Die.DieByValue[_random.Next(1, 7)];
        var b = Die.DieByValue[_random.Next(1, 7)];

        var roll = new Roll(a, b);

        return roll;
    }
}
