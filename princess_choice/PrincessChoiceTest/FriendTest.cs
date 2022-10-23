using FluentAssertions;
using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class FriendTest
{
    private readonly IFriend _friend = new Friend();
    private Contender _bestContender;

    [SetUp]
    public void SetUp()
    {
        _bestContender = new Contender("Chuck Bass", 100);
        var worstContender = new Contender("Bart Bass", 50);
        _friend.AddPassedContender(worstContender);
    }

    [Test]
    public void BestContender_VisitedPrincess_Remember()
    {
        _friend.AddPassedContender(_bestContender);
        _friend.RememberContenderIfBest(_bestContender);
        ((Friend)_friend).LastBestContender.Should().NotBeNull();
    }

    [Test]
    public void BestContender_NotVisitedPrincess_ThrowError()
    {
        var act = () => _friend.RememberContenderIfBest(_bestContender);
        act.Should().Throw<ArgumentException>()
            .WithMessage("Current contender not visited princess!");
    }

    [Test]
    public void IsContenderBest_PrincessVisitByBestContender_HeBest()
    {
        _friend.AddPassedContender(_bestContender);
        _friend.IsCurrContenderBest(_bestContender).Should().BeTrue();
    }

    [Test]
    public void IsContenderBest_PrincessNotVisitByBestContender_ThrowError()
    {
        var act = () => _friend.IsCurrContenderBest(_bestContender);
        act.Should().Throw<ArgumentException>()
            .WithMessage("Current contender not visited princess!");
    }
}