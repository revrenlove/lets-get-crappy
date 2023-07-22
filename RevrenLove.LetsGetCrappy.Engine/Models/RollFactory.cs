namespace RevrenLove.LetsGetCrappy.Engine.Models;

public class RollFactory
{
    public static Roll CreateRoll(IDie a, IDie b) => new(a, b);
}
