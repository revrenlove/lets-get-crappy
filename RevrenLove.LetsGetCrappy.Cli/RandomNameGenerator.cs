namespace RevrenLove.LetsGetCrappy.Cli;

public class RandomNameGenerator
{
    private readonly Random _random;

    private static readonly List<string> _names = new()
    {
        "John",
        "Paul",
        "George",
        "Ringo",
    };

    public RandomNameGenerator(Random random)
    {
        _random = random;
    }

    public string Generate(string? nameToExclude = null)
    {
        var index = _random.Next(_names.Count);

        var name = _names[index];

        if (!string.IsNullOrWhiteSpace(nameToExclude))
        {
            while (name == nameToExclude)
            {
                name = Generate(nameToExclude);
            }
        }

        return name;
    }
}
