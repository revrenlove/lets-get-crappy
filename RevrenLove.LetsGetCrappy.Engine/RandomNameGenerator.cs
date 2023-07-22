namespace RevrenLove.LetsGetCrappy.Engine;

public class RandomNameGenerator
{
    private readonly Random _random;

    private static readonly List<string> _names = new()
    {
        "Alfred",
        "Bert",
        "Chuck",
        "Dave",
        "Eric",
        "Frank",
        "Greg",
        "Hank",
        "Ian",
        "John",
        "Ken",
        "Layne",
        "Matt",
        "Nathan",
        "Otto",
        "Patrick",
        "Quincy",
        "Ryan",
        "Steve",
        "Ted",
        "Ulysses",
        "Vic",
        "Walter",
        "Xavier",
        "Yancy",
        "Zed",
    };

    public RandomNameGenerator(Random random)
    {
        _random = random;
    }

    public string Generate(string? nameToExclude = null)
    {
        var clonedNames = new List<string>(_names);

        if (!string.IsNullOrWhiteSpace(nameToExclude))
        {
            clonedNames.Remove(nameToExclude);
        }

        var index = _random.Next(clonedNames.Count);

        var name = _names[index];

        return name;
    }
}
