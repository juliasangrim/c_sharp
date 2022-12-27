using PrincessChoice.Model;

namespace PrincessChoice.Generator;

public static class ContenderGenerator
{
    private static string[] _firstNames = {"Ben", "Bart", "Carter", "Rufus", "Dan", "Chuck", "Nate", "Eric", "Jack", "Cyrus"};
    private static string[] _lastNames = {"Donovan", "Bass", "Humphrey", "Baizen", "Rose", "Archibald", "van der Woodsen", "Waldorf", "Sparks", "Dickens"};

    /// <summary>
    /// This method generate name for contenders.
    /// </summary>
    /// <returns>
    /// Returns 100 generated contender names 
    /// </returns>
    private static List<string> GenerateNames()
    {
        var contenderNames = (
            from fName in _firstNames 
            from sName in _lastNames
            select $"{fName} {sName}").ToList();
        return contenderNames;
    }
    
    /// <summary>
    /// Shuffle list of waiting contenders.
    /// </summary>
    /// <param name="contenders">Not mixed contenders list.</param>
    /// <returns>Mixed contenders list.</returns>
    private static List<Contender> MixContenders(List<Contender> contenders)
    {
        var random = new Random(DateTime.Now.Millisecond);
         contenders = contenders.OrderBy(_ => random.Next()).ToList();
         return contenders;
    }

    /// <summary>
    /// Generate group of 100 contenders.
    /// </summary>
    public static List<Contender> GenerateContenders()
    {
        var contenders = new List<Contender>();
        var contenderNames = ContenderGenerator.GenerateNames();
        for (var i = 1; i <= contenderNames.Count; ++i)
        {
            contenders.Add(new Contender(contenderNames[i - 1], i));
        }
        
        return MixContenders(contenders);
    }
}
