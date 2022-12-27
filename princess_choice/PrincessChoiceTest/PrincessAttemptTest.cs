using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PrincessChoice.Context;
using PrincessChoice.DbModel;
using PrincessChoice.Mapper;
using PrincessChoice.Model;
using PrincessChoice.Strategy;

namespace PrincessChoiceTest;

public class PrincessAttemptTest
{
    private IFriend _friend;
    private PostgresDbContext _postgresDbContext;
    private readonly ILogger<Princess> _logger = Substitute.For<ILogger<Princess>>();
    private const int ContenderCount = 100;

    [SetUp]
    public void SetUp()
    {
        _friend = new Friend();
        var options = new DbContextOptionsBuilder<PostgresDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _postgresDbContext = new PostgresDbContext(options);
    }

    private List<Contender> GenerateContendersAscending()
    {
        var contenders = new List<Contender>();
        for (var i = 1; i <= ContenderCount; ++i)
        {
            contenders.Add(new Contender(i.ToString(), i));
        }

        return contenders;
    }

    [Test]
    public void AttemptInDB_FirstContenderInSecondPartWithValueLessThan50_PrincessUnhappy()
    {
        var contenders = GenerateContendersAscending();
        var attempt = new PrinceAttemptEntity()
        {
            AttemptName = PrincessResource.AttemptName,
            Contenders = ContendersListMapper.Map(contenders)
        };
        _postgresDbContext.PrinceAttempt.Add(attempt);
        _postgresDbContext.SaveChanges();

        var hall = new HallDb(_postgresDbContext);
        var strategy = new OptimalStrategy(_friend, hall);
        var princess = new Princess(hall, strategy, _logger);

        princess.CountHappy(PrincessResource.AttemptName).Should().Be(0);
    }

    [Test]
    public void AttemptInDb_PassWrongAttemptName_ThrowError()
    {
        var contenders = GenerateContendersAscending();
        var attempt = new PrinceAttemptEntity()
        {
            AttemptName = PrincessResource.AttemptName,
            Contenders = ContendersListMapper.Map(contenders)
        };
        _postgresDbContext.PrinceAttempt.Add(attempt);
        _postgresDbContext.SaveChanges();

        var hall = new HallDb(_postgresDbContext);
        var strategy = new OptimalStrategy(_friend, hall);
        var princess = new Princess(hall, strategy, _logger);

        var act = () => princess.CountHappy(PrincessResource.WrongAttemptName);
        act.Should().ThrowAsync<ArgumentException>()
            .WithMessage(PrincessResource.WrongAttemptNameError);
    }

    [Test]
    public void AttemptInDb_PassNullAttemptName_ThrowError()
    {
        var contenders = GenerateContendersAscending();
        var attempt = new PrinceAttemptEntity()
        {
            AttemptName = PrincessResource.AttemptName,
            Contenders = ContendersListMapper.Map(contenders)
        };
        _postgresDbContext.PrinceAttempt.Add(attempt);
        _postgresDbContext.SaveChanges();

        var hall = new HallDb(_postgresDbContext);
        var strategy = new OptimalStrategy(_friend, hall);
        var princess = new Princess(hall, strategy, _logger);

        var act = () => princess.CountHappy(null);
        act.Should().ThrowAsync<ArgumentException>()
            .WithMessage(PrincessResource.NullAttemptNameError);
    }
}