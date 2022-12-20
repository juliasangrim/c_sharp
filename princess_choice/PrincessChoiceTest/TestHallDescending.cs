using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class TestHallDescending : Hall
{
    private const int ContenderCount = 100;
    
    public override void CallNextGroup(string? attemptName)
    {
        for (var i = ContenderCount; i >= 1; --i)
        {
            _allContenders.Add(new Contender(i.ToString(), i));
        }

        _enumerator = _allContenders.GetEnumerator();
    }
}