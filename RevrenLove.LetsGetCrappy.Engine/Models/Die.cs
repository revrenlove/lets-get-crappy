namespace RevrenLove.LetsGetCrappy.Engine.Models;

public class Die
{
    public static readonly Die One = new(1, nameof(One), '⚀');
    public static readonly Die Two = new(2, nameof(Two), '⚁');
    public static readonly Die Three = new(3, nameof(Three), '⚂');
    public static readonly Die Four = new(4, nameof(Four), '⚃');
    public static readonly Die Five = new(5, nameof(Five), '⚄');
    public static readonly Die Six = new(6, nameof(Six), '⚅');

    public Die(int value, string name, char symbol)
    {
        Value = value;
        Name = name;
        Symbol = symbol;
    }

    public int Value { get; }
    public string Name { get; }
    public char Symbol { get; }

    public static Dictionary<int, Die> DieByValue = new()
    {
        {1, Die.One},
        {2, Die.Two},
        {3, Die.Three},
        {4, Die.Four},
        {5, Die.Five},
        {6, Die.Six},
    };
}
