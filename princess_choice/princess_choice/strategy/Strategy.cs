namespace princess_choice;

public class Strategy : IStrategy

{
    private Friend _friend;
    private Hall _hall;
    private Contender? _bestContender;
    private int _countContender;
    private int _bound;
    
    public Strategy(Friend friend, Hall hall)
    {
        _hall = hall;
        _friend = friend;
        _countContender = 0;
        _bound = (int)(hall.CountContender() / Math.E);
    }

    public Contender? BestContender()
    {
        var newContender = _hall.NextContender();
        while (newContender != null)
        {
            _friend.AddPassedContender(newContender);
            if (_countContender <= _bound)
            {
                if (_friend.IsHeBest(newContender, _bestContender))
                {
                    _bestContender = newContender;
                }
            }
            else
            {
                if (_friend.IsHeBest(newContender, _bestContender))
                {
                    return newContender;
                }
            }
            newContender = _hall.NextContender();
            _countContender++;
        }

        return null;
    }
}