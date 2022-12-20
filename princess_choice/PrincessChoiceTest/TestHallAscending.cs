using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class TestHallAscending : Hall
{
    private const int ContenderCount = 100;
    
    public override void CallNextGroup(string? attemptName)
    {
        for (var i = 1; i <= ContenderCount; ++i)
        {
            _allContenders.Add(new Contender(i.ToString(), i));
        }

        _enumerator = _allContenders.GetEnumerator();
    }
}