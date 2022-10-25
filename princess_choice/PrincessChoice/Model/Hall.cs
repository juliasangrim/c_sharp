using PrincessChoice.Generator;

namespace PrincessChoice.Model;

public class Hall : IHall
{
    /// <summary>
    /// List of all waiting contenders.
    /// </summary>
    private List<Contender> _allContenders;

    /// <summary>
    /// Enumerator for list of waiting contenders.
    /// </summary>
    private List<Contender>.Enumerator _enumerator;

    public Hall()
    {
        _allContenders = new List<Contender>();
        _enumerator = _allContenders.GetEnumerator();
    }

    /// <summary>
    /// Shuffle list of waiting contenders.
    /// </summary>
    private void MixContenders()
    {
        var random = new Random(DateTime.Now.Millisecond);
        _allContenders = _allContenders.OrderBy(_ => random.Next()).ToList();
    }

    /// <summary>
    /// Generate new group of 100 contenders.
    /// </summary>
    public void CallNextGroup()
    {
        var contenderNames = ContenderNameGenerator.GenerateNames();
        for (var i = 1; i <= contenderNames.Count; ++i)
        {
            _allContenders.Add(new Contender(contenderNames[i - 1], i));
        }
        
        MixContenders();
        _enumerator = _allContenders.GetEnumerator();
    }

    /// <summary>
    /// Get next waiting contenders.
    /// </summary>
    /// <returns>Returns next waiting contender if exist, otherwise return null.</returns>
    public Contender? NextContender()
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