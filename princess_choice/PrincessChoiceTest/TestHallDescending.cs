using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class TestHallDescending : Hall
{
    public override void CallNextGroup(string? attemptName)
    {
        var contenderCount = int.Parse(PrincessResource.ContenderCount);
        for (var i = contenderCount; i >= 1; --i)
        {
            _allContenders.Add(new Contender(i.ToString(), i));
        }

        _enumerator = _allContenders.GetEnumerator();
    }
}