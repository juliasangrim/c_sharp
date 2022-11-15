using PrincessChoice.Generator;
using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class TestHallFirstContenderInSecondPartWithBiggestValue : Hall
{
    public override void CallNextGroup()
    {
        var contenderNames = ContenderNameGenerator.GenerateNames();
        for (var i = 1; i <= contenderNames.Count; ++i)
        {
            _allContenders.Add(new Contender(contenderNames[i - 1], i));
        }

        var bound = (int)(contenderNames.Count / Math.E);
        var contenderWithBiggestValueIndex =
            _allContenders.FindIndex(0, contender => contender.Value == contenderNames.Count);
        
        (_allContenders[contenderWithBiggestValueIndex], _allContenders[bound]) = 
            (_allContenders[bound], _allContenders[contenderWithBiggestValueIndex]);
        _enumerator = _allContenders.GetEnumerator();
    }
}