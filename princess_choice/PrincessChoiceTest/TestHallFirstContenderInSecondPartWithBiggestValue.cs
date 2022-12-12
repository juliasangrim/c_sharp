using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class TestHallFirstContenderInSecondPartWithBiggestValue : Hall
{
    public override void CallNextGroup(string? attemptName)
    {
        var contenderCount = int.Parse(PrincessResource.ContenderCount);
        for (var i = 1; i <= contenderCount; ++i)
        {
            _allContenders.Add(new Contender(i.ToString(), i));
        }

        var bound = (int)(contenderCount / Math.E);
        var contenderWithBiggestValueIndex =
            _allContenders.FindIndex(0, contender => contender.Value == contenderCount);

        (_allContenders[contenderWithBiggestValueIndex], _allContenders[bound]) =
            (_allContenders[bound], _allContenders[contenderWithBiggestValueIndex]);
        _enumerator = _allContenders.GetEnumerator();
    }
}