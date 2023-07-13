namespace RevrenLove.LetsGetCrappy.Engine.Models;

public class Roll
{
    private static readonly List<int> _crapsValues = new() { 2, 3, 12 };
    private static readonly List<int> _naturalValues = new() { 7, 11 };

    public Roll(Die a, Die b)
    {
        Dice = new Die[2] { a, b };
    }

    public Die[] Dice { get; }
    public int Value => Dice.Select(d => d.Value).Sum();
    public string Name => GetName();

    public bool IsNatural => _naturalValues.Contains(Value);
    public bool IsCraps => _crapsValues.Contains(Value);

    private bool IsDouble => Dice[0].Value == Dice[1].Value;

    private string GetName()
    {
        return Value switch
        {
            2 => "Snake Eyes",
            3 => "Ace Deuce",
            4 => IsDouble ? "Hard Four" : "Easy Four",
            5 => "Five",
            6 => IsDouble ? "Hard Six" : "Easy Six",
            7 => "Natural",
            8 => IsDouble ? "Hard Eight" : "Easy Eight",
            9 => "Nine",
            10 => IsDouble ? "Hard Ten" : "Easy Ten",
            11 => "Yo",
            12 => "Boxcars",
            _ => throw new InvalidOperationException("This class only supports 2 six-sided dice."),
        };
    }
}
