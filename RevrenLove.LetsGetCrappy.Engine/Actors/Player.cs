using RevrenLove.LetsGetCrappy.Engine.Strategies;

namespace RevrenLove.LetsGetCrappy.Engine.Actors;

public class Player
{
    internal Player() { }

    public string Name { get; init; } = default!;
    public int Wallet { get; init; }
    public IStrategy? Strategy { get; init; }
}
