namespace princess_choice;

public class Hall : IHall
{
    /// <summary>
    /// List of all waiting contenders.
    /// </summary>
    private readonly List<IContender> _allContenders;

    /// <summary>
    /// Enumerator for list of waiting contenders.
    /// </summary>
    private List<IContender>.Enumerator _enumerator;

    public Hall()
    {
        _allContenders = new List<IContender>();
        var contenderNames = ContenderNameGenerator.GenerateNames();
        for (var i = 1; i <= contenderNames.Count; ++i)
        {
            _allContenders.Add(new Contender(contenderNames[i - 1], i));
        }

        MixContenders();
        _enumerator = _allContenders.GetEnumerator();
    }

    /// <summary>
    /// Shuffle list of waiting contenders.
    /// </summary>
    private void MixContenders()
    {
        var random = new Random(DateTime.Now.Millisecond);
        for (int i = _allContenders.Count - 1; i >= 0; --i)
        {
            var randomIndex = random.Next(_allContenders.Count);
            (_allContenders[i], _allContenders[randomIndex]) = (_allContenders[randomIndex], _allContenders[i]);
        }
    }

    /// <summary>
    /// Get next waiting contenders.
    /// </summary>
    /// <returns>Returns next waiting contender if exist, otherwise return null.</returns>
    public IContender? NextContender()
    {
        if (_enumerator.MoveNext())
        {
            return _enumerator.Current;
        }

        return null;
    }

    /// <summary>
    /// Get amount of contenders.
    /// </summary>
    /// <returns>Returns amount of contenders in list.</returns>
    public int CountContender()
    {
        return _allContenders.Count;
    }
}