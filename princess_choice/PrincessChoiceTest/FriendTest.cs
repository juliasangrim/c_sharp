using FluentAssertions;
using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class FriendTest
{
    private IFriend _friend;
    private Contender _bestContender;

    [SetUp]
    public void SetUp()
    {
        _friend = new Friend();
        _bestContender = new Contender("Chuck Bass", 100);
        var currWorstContender = new Contender("Bart Bass", 50);
        _friend.AddPassedContender(currWorstContender);
        _friend.RememberContenderIfBest(currWorstContender);
    }

    [Test]
    public void CheckWhoBest_IfСurrContenderBestAndPrincessVisitedByThisContender_ReturnTrue()
    {
        _friend.AddPassedContender(_bestContender);
        _friend.IsCurrContenderBest(_bestContender).Should().BeTrue();
    }
    
    [Test]
    public void CheckWhoBest_IfCurrContenderWorstAndPrincessVisitedByThisContender_ReturnFalse()
    {
        var currWorstContender = new Contender("Carter Baizen", 20);
        _friend.AddPassedContender(currWorstContender);
        _friend.IsCurrContenderBest(currWorstContender).Should().BeFalse();
    }

    [Test]
    public void CheckWhoBest_IfContenderBestAndPrincessNotVisitedByThisContender_ThrowError()
    {
        var act = () => _friend.IsCurrContenderBest(_bestContender);
        act.Should().Throw<ArgumentException>()
            .WithMessage(PrincessResource.NotVisitedComparisonError);
    }
}