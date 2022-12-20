using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class TestHallFirstContenderInSecondPartWithBiggestValue : Hall
{
    private const int ContenderCount = 100;
    
    public override void CallNextGroup(string? attemptName)
    {
        for (var i = 1; i <= ContenderCount; ++i)
        {
            _allContenders.Add(new Contender(i.ToString(), i));
        }

        var bound = (int)(ContenderCount / Math.E);
        var contenderWithBiggestValueIndex =
            _allContenders.FindIndex(0, contender => contender.Value == ContenderCount);

        (_allContenders[contenderWithBiggestValueIndex], _allContenders[bound]) =
            (_allContenders[bound], _allContenders[contenderWithBiggestValueIndex]);
        _enumerator = _allContenders.GetEnumerator();
    }
}