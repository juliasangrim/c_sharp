using FluentAssertions;
using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class HallTest
{
    private readonly IHall _testHall = new Hall();

    [Test]
    public void CallNextContender_CorrectCall()
    {
        _testHall.CallNextGroup();
        _testHall.NextContender().Should().NotBeNull();
    }

    [Test]
    public void CallNextContender_IfHallEmpty_BeNull()
    {
        _testHall.NextContender().Should().BeNull();
    }
}