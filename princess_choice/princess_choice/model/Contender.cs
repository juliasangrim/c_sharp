namespace princess_choice;

public class Contender
{
    private string _name;
    private int _matchScore;

    public Contender(string name, int matchScore)
    {
        _matchScore = matchScore;
        _name = name;
    }

    public override string ToString()
    {
        return _name;
    }  
    
    public int MatchScore
    {
        get => _matchScore;
    }
}