namespace RevrenLove.LetsGetCrappy.Engine.Actors;

public class ShooterFactory
{
    private readonly Random _random;

    public ShooterFactory(Random random)
    {
        _random = random;
    }

    public Shooter CreateShooter(string name)
    {
        return new Shooter(_random, name);
    }
}
