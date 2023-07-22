namespace RevrenLove.LetsGetCrappy.Engine.Bets;

public interface IBet
{
    string Name { get; }
    BetRollType BetRollType { get; }

}
