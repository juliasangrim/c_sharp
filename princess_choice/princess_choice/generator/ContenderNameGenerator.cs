namespace princess_choice;

public class ContenderNameGenerator
{
    private static string[] _firstName = {"Ben", "Bart", "Carter", "Rufus", "Dan", "Chuck", "Nate", "Eric", "Jack", "Cyrus"};
    private static string[] _lastName = {"Donovan", "Bass", "Humphrey", " Baizen", "Rose", "Archibald", "van der Woodsen", "Waldorf", "Sparks", "Dickens"};
    
    
    public static List<string> GenerateNames()
    {
        var contenderNames = (
            from fName in _firstName 
            from sName in _lastName
            select $"{fName} {sName}").ToList();
        return contenderNames;
    }
    
}
