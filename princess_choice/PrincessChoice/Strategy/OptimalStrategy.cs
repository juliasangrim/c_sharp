using PrincessChoice.Model;

namespace PrincessChoice.Strategy;

public class OptimalStrategy : IStrategy
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
    /// the best prince for princess.
    /// </summary>
    private Contender? _bestContender;

    /// <summary>
    /// Counter of passed contenders.
    /// </summary>
    private int _contenderCount;

    /// <summary>
    /// The bound to which all the princes are skipped.(this is such a condition of the strategy)
    /// </summary>
    private int _bound;

    public OptimalStrategy(IFriend friend, IHall hall)
    {
        _hall = hall;
        _friend = friend;
        _contenderCount = 0;
        _bound = 0;
        _bestContender = null;
    }

    /// <summary>
    /// Choose the best contender.
    /// </summary>
    /// <returns>Returns the best contender if he exist,
    /// otherwise return null.</returns>
    public void BestContender()
    {
        _bestContender = null;
        _contenderCount = 0;
        _friend.ForgetAllPastContenders();
        _bound = (int)(_hall.CountContender() / Math.E);
        var currContender = _hall.NextContender();
        while (currContender != null)
        {
            _friend.AddPassedContender(currContender);
            if (_contenderCount >= _bound
                && _friend.IsCurrContenderBest(currContender))
            {
                _bestContender = currContender;
                return;
            }

            _friend.RememberContenderIfBest(currContender);
            currContender = _hall.NextContender();
            _contenderCount++;
        }
    }

    /// <summary>
    /// Get best contender value;
    /// </summary>
    /// <returns>Returns best contender value, if he exist,
    /// otherwise return null.</returns>
    public int? BestContenderValue()
    {
        return _bestContender?.Value;
    }
}