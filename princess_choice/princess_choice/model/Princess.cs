namespace princess_choice;

public class Princess
{
    private IStrategy _strategy;
    private Contender? _prince;
    public Princess(Friend friend, Hall hall)
    {
       
        _strategy = new Strategy(friend, hall);
    }
    
    public int CountHappy()
    {
        var happiness = 0;
        _prince = _strategy.BestContender();
        if (_prince != null)
        {
            if (_prince.MatchScore > IStrategy.MaxMatchScore / 2 )
            {
                happiness = _prince.MatchScore;
            }
        }
        else
        {
            happiness = 10;
        }

        return happiness;
    }
}