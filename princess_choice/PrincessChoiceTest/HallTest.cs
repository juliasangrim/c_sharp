using FluentAssertions;
using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class HallTest
{
    private IHall _testHall;

    [SetUp]
    public void SetUp()
    {
        _testHall = new Hall();
    }

    [Test]
    public void CallNextContender_NotNull()
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