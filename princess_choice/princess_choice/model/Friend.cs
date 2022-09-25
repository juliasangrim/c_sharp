namespace princess_choice;

public class Friend : IFriend
{
    /// <summary>
    /// The best contender of all passed contenders.
    /// </summary>
    private IContender? _lastBestContender;

    /// <summary>
    /// The list of passed contenders.
    /// </summary>
    public List<IContender> PassedContenders { get; }

    public Friend()
    {
        _lastBestContender = null;
        PassedContenders = new List<IContender>();
    }

    /// <summary>
    /// Add contender in list of passed contenders and choose the best of them.
    /// </summary>
    /// <param name="passedContender"> Contender rejected by the princess.</param>
    public void AddPassedContender(IContender passedContender)
    {
        if (_lastBestContender == null ||
            _lastBestContender.Value() < passedContender.Value())
        {
            _lastBestContender = passedContender;
        }

        PassedContenders.Add(passedContender);
    }

    /// <summary>
    /// Detect the best contender.
    /// </summary>
    /// <param name="currContender">The contender who is with the princess now.</param>
    /// <returns>Returns true - if contender with the princess is better than last best contender,
    /// otherwise - return false</returns>
    public bool IsCurrContenderBest(IContender currContender)
    {
        if (_lastBestContender == null)
        {
            return true;
        }

        if (!PassedContenders.Contains(_lastBestContender))
        {
            throw new ArgumentException("Contender not in list of passed contenders!");
        }

        return _lastBestContender.Value() < currContender.Value();
    }
}