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
    private IFriend _friend;
    private IWriter _writer = Substitute.For<IWriter>();
    private readonly IHostApplicationLifetime _lifetime = Substitute.For<IHostApplicationLifetime>();
    private readonly ILogger<Princess> _logger = Substitute.For<ILogger<Princess>>();

    [SetUp]
    public void SetUp()
    {
        _friend = new Friend();   
    }

    /// <summary>
    /// By strategy, first N/e (N - contender count in hall, e - mathematical constant) contenders are skipped,
    /// and after that princess choose the first contender,
    /// who has bigger value, than skipped contenders. If value less than 50, princess becomes unhappy.
    /// </summary>
    [Test]
    public void ChoosePrince_FirstContenderInSecondPartWithValueLessThan50_PrincessUnhappy()
    {
        var testHall = new TestHallAscending();
        var strategy = new OptimalStrategy(_friend, testHall, _writer);
        var princess = new Princess(testHall, _writer, strategy, _lifetime, _logger);
        princess.ChoosePrince();
        princess.CountHappy().Should().Be(0);
    }

    /// <summary>
    /// By strategy, first N/e (N - contender count in hall, e - mathematical constant) contenders are skipped,
    /// and after that princess choose the first contender,
    /// who has bigger value, than skipped contenders. If contender with biggest value was in skipped part,
    /// princess becomes happy alone(her happiness equivalent 10).///
    /// </summary>
    [Test]
    public void ChooseContender_BestContenderInFirstPart_PrincessHappyAlone()
    {
        var testHall = new TestHallDescending();
        var strategy = new OptimalStrategy(_friend, testHall, _writer);
        var princess = new Princess(testHall, _writer, strategy, _lifetime, _logger);
        princess.ChoosePrince();
        princess.CountHappy().Should().Be(10);
    }

    /// <summary>
    /// By strategy, first N/e (N - contender count in hall, e - mathematical constant) contenders are skipped,
    /// and after that princess choose the first contender,
    /// who has bigger value, than skipped contenders. If his value was bigger, than 50, princess become happy.///
    /// </summary>
    [Test]
    public void ChooseContender_FirstContenderInSecondPartWithValueBiggerThan50_PrincessHappy()
    {
        var testHall = new TestHallFirstContenderInSecondPartWithBiggestValue();
        var strategy = new OptimalStrategy(_friend, testHall, _writer);
        var princess = new Princess(testHall, _writer, strategy, _lifetime, _logger);
        princess.ChoosePrince();
        princess.CountHappy().Should().Be(100);
    }
}