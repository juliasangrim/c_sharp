using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PrincessChoice.Model;
using PrincessChoice.Strategy;
using PrincessChoice.Writer;

namespace PrincessChoiceTest;

public class PrincessTest
{
    private readonly IFriend _friend = new Friend();
    private readonly IWriter _writer = Substitute.For<IWriter>();
    private readonly IHostApplicationLifetime _lifetime = Substitute.For<IHostApplicationLifetime>();
    private readonly ILogger<Princess> _logger = Substitute.For<ILogger<Princess>>();

    [Test]
    public void PrincessStrategy_BestContenderInSecondPart_PrincessUnhappy()
    {
        var testHall = new TestHallAscending();
        var strategy = new OptimalStrategy(_friend, testHall, _writer);
        var princess = new Princess(testHall, _writer, strategy, _lifetime, _logger);
        princess.ChoosePrince();
        princess.CountHappy().Should().Be(0);
    }

    [Test]
    public void PrincessStrategy_BestContenderInFirstPart_PrincessHappyAlone()
    {
        var testHall = new TestHallDescending();
        var strategy = new OptimalStrategy(_friend, testHall, _writer);
        var princess = new Princess(testHall, _writer, strategy, _lifetime, _logger);
        princess.ChoosePrince();
        princess.CountHappy().Should().Be(10);
    }
}