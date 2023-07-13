namespace RevrenLove.LetsGetCrappy.Engine.Actors;

public class ShooterFactory
{
    private readonly Random _random;

    public ShooterFactory(Random random)
    {
        _random = random;
    }

    public Shooter CreateShooter()
    {
        return new Shooter(_random);
    }
}
