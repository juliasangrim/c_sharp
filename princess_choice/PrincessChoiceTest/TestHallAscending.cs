using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class TestHallAscending : Hall
{
    public override void CallNextGroup(string? attemptName)
    {
        var contenderCount = int.Parse(PrincessResource.ContenderCount);
        for (var i = 1; i <= contenderCount; ++i)
        {
            _allContenders.Add(new Contender(i.ToString(), i));
        }

        _enumerator = _allContenders.GetEnumerator();
    }
}