using PrincessChoice.Generator;
using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class TestHallAscending : Hall
{
    public override void CallNextGroup()
    {
        var contenderNames = ContenderNameGenerator.GenerateNames();
        for (var i = 1; i <= contenderNames.Count; ++i)
        {
            _allContenders.Add(new Contender(contenderNames[i - 1], i));
        }

        _enumerator = _allContenders.GetEnumerator();
    }
}