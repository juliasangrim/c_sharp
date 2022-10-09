namespace princess_choice.generator;

public class ContenderNameGenerator
{
    private static string[] _firstNames = {"Ben", "Bart", "Carter", "Rufus", "Dan", "Chuck", "Nate", "Eric", "Jack", "Cyrus"};
    private static string[] _lastNames = {"Donovan", "Bass", "Humphrey", "Baizen", "Rose", "Archibald", "van der Woodsen", "Waldorf", "Sparks", "Dickens"};

    ContenderNameGenerator()
    {
    }

    /// <summary>
    /// This method generate name for contenders.
    /// </summary>
    /// <returns>
    /// Returns 100 generated contender names 
    /// </returns>
    public static List<string> GenerateNames()
    {
        var contenderNames = (
            from fName in _firstNames 
            from sName in _lastNames
            select $"{fName} {sName}").ToList();
        return contenderNames;
    }
}
