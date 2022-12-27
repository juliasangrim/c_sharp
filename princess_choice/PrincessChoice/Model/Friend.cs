namespace PrincessChoice.Model;

public class Friend : IFriend
{
    /// <summary>
    /// The best contender of all passed contenders.
    /// </summary>
    private Contender? _lastBestContender;

    /// <summary>
    /// The list of passed contenders.
    /// </summary>
    private List<Contender> _passedContenders;

    public Friend()
    {
        _lastBestContender = null;
        _passedContenders = new List<Contender>();
    }

    /// <summary>
    /// Delete all contenders in friend list.
    /// </summary>
    public void ForgetAllPastContenders()
    {
        _lastBestContender = null;
        _passedContenders = new List<Contender>();
    }

    /// <summary>
    /// Checked if contender visited princess or not.
    /// </summary>
    /// <param name="contender">Contender we are checking.</param>
    /// <returns>Returns true, if contender visited princess, false - otherwise.</returns>
    private bool IsContenderPassed(Contender contender)
    {
        return _passedContenders.Any(passedContender =>
            passedContender.Name == contender.Name & passedContender.Value == contender.Value);
    }

    /// <summary>
    /// Add contender in list of passed contenders and choose the best of them.
    /// </summary>
    /// <param name="passedContender"> Contender rejected by the princess.</param>
    public void AddPassedContender(Contender passedContender)
    {
        _passedContenders.Add(passedContender);
    }

    /// <summary>
    /// Detect the best contender.
    /// </summary>
    /// <param name="currContender">The contender who is with the princess now.</param>
    /// <returns>Returns true - if contender with the princess is better than last best contender,
    /// otherwise - return false</returns>
    public bool IsCurrContenderBest(Contender currContender)
    {
        if (!IsContenderPassed(currContender))
            throw new ArgumentException("Current contender not visited princess!");

        return _lastBestContender == null ||
               _lastBestContender.Value < currContender.Value;
    }

    /// <summary>
    /// Friend track, who from passed contenders are best. This method allow you to remember contender if he better than other
    /// passed contenders.
    /// </summary>
    /// <param name="currContender">Contender, whom we want to remember.</param>
    /// <exception cref="ArgumentException">Throws when contender with that name not found.</exception>
    public void RememberContenderIfBest(Contender currContender)
    {
        if (!IsContenderPassed(currContender))
            throw new ArgumentException("Current contender not visited princess!");
        if (_lastBestContender == null ||
            _lastBestContender.Value < currContender.Value)
        {
            _lastBestContender = currContender;
        }
    }
}