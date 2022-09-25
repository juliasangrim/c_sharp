namespace princess_choice;

public class Strategy : IStrategy
{
    /// <summary>
    /// The friend of princess. Helps the princess choose her best prince.
    /// </summary>
    private readonly IFriend _friend;

    /// <summary>
    /// Place, where all prince-contenders waiting for a meeting with princess.
    /// </summary>
    private readonly IHall _hall;

    /// <summary>
    /// Counter of passed contenders.
    /// </summary>
    private int _contenderCount;

    /// <summary>
    /// The bound to which all the princes are skipped.(this is such a condition of the strategy)
    /// </summary>
    private int _bound;

    public Strategy(IFriend friend, IHall hall)
    {
        _hall = hall;
        _friend = friend;
        _contenderCount = 0;
        _bound = (int)(hall.CountContender() / Math.E);
    }

    /// <summary>
    /// Choose the best contender.
    /// </summary>
    /// <returns>Returns the best contender if he exist,
    /// otherwise return null.</returns>
    public IContender? BestContender()
    {
        var currContender = _hall.NextContender();
        while (currContender != null)
        {
            if (_contenderCount >= _bound
                && _friend.IsCurrContenderBest(currContender))
            {
                _friend.AddPassedContender(currContender);
                return currContender;
            }

            _friend.AddPassedContender(currContender);
            currContender = _hall.NextContender();
            _contenderCount++;
        }

        return null;
    }
}