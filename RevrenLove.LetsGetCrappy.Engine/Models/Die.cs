namespace RevrenLove.LetsGetCrappy.Engine.Models;

internal class Die : IDie
{
    public static readonly IDie One = new Die(1, nameof(One), '⚀');
    public static readonly IDie Two = new Die(2, nameof(Two), '⚁');
    public static readonly IDie Three = new Die(3, nameof(Three), '⚂');
    public static readonly IDie Four = new Die(4, nameof(Four), '⚃');
    public static readonly IDie Five = new Die(5, nameof(Five), '⚄');
    public static readonly IDie Six = new Die(6, nameof(Six), '⚅');

    private Die(int value, string name, char symbol)
    {
        Value = value;
        Name = name;
        Symbol = symbol;
    }

    public int Value { get; }
    public string Name { get; }
    public char Symbol { get; }

    private static readonly Dictionary<int, IDie> DieByValue = new()
    {
        {1, One},
        {2, Two},
        {3, Three},
        {4, Four},
        {5, Five},
        {6, Six},
    };

    public static IDie GetDyeByValue(int value)
    {
        return DieByValue[value];
    }
}
