using System.Collections;

namespace princess_choice;

public class Hall 
{
    private List<Contender> _allContenders;
    private List<Contender>.Enumerator _enumerator;

    public Hall(int countContenders)
    {
        var allContenders = new List<Contender>();
        var contenderNames = ContenderNameGenerator.GenerateNames();
        for (int i = 1; i <= countContenders; ++i)
        {
            allContenders.Add(new Contender(contenderNames[i - 1], i));
        }

        _allContenders = MixContenders(allContenders);
        _enumerator = _allContenders.GetEnumerator();
    }

    private static List<Contender> MixContenders(IList<Contender> contenders)
    {
        var mixedContenders = new List<Contender>();
        var random = new Random(DateTime.Now.Millisecond);  
        while (contenders.Count != 0)
        {
            var index = random.Next(0, contenders.Count);
            mixedContenders.Add(contenders[index]);
            contenders.RemoveAt(index);
        }
        return mixedContenders;
    }

    public List<Contender> AllContenders
    {
        get => _allContenders;
    }

    public Contender? NextContender()
    {
        if (_enumerator.MoveNext())
        {
            return _enumerator.Current;
        }

        return null;
    }

    public int CountContender()
    {
        return _allContenders.Count;
    }

}