using PrincessChoice.Generator;
using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class TestHallDescending : Hall
{
    public override void CallNextGroup()
    {
        var contenderNames = ContenderNameGenerator.GenerateNames();
        for (var i = contenderNames.Count; i >= 1; --i)
        {
            _allContenders.Add(new Contender(contenderNames[i - 1], i));
        }

        _enumerator = _allContenders.GetEnumerator();
    }
}