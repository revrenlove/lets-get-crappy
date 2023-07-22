using RevrenLove.LetsGetCrappy.Engine.Strategies;

namespace RevrenLove.LetsGetCrappy.Engine.Actors;

public class PlayerFactory
{
    private readonly RandomNameGenerator _randomNameGenerator;

    public PlayerFactory(RandomNameGenerator randomNameGenerator)
    {
        _randomNameGenerator = randomNameGenerator;
    }

    public Player CreatePlayer(
        int wallet,
        string? name = null,
        IStrategy? strategy = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            name = _randomNameGenerator.Generate();
        }

        return new()
        {
            Name = name,
            Wallet = wallet,
            Strategy = strategy,
        };
    }
}
