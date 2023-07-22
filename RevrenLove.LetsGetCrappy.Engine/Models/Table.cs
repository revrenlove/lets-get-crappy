using RevrenLove.LetsGetCrappy.Engine.Actors;
using RevrenLove.LetsGetCrappy.Engine.Bets;

namespace RevrenLove.LetsGetCrappy.Engine.Models;

public class Table
{
    public List<Player> Players { get; }
    public List<IBet> Bets { get; }
}
