using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PrincessChoice.Context;
using PrincessChoice.DbModel;
using PrincessChoice.Mapper;
using PrincessChoice.Model;

namespace PrincessChoiceTest;

public class HallTest
{
    private IHall _testHall;
    
    private const int ContenderCount = 100;
    private const string AttemptName = "1";

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<PostgresDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var postgresDbContext = new PostgresDbContext(options);
        var contenders = GenerateContendersAscending();
        var attempt = new PrinceAttemptEntity()
        {
            AttemptName = AttemptName,
            Contenders = ContendersListMapper.Map(contenders)
        };
        postgresDbContext.PrinceAttempt.Add(attempt);
        postgresDbContext.SaveChanges();
        _testHall = new HallDb(postgresDbContext);
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
    public void CallNextContender_NotNull()
    {
        _testHall.CallNextGroup(AttemptName);
        _testHall.NextContender().Should().NotBeNull();
    }

    [Test]
    public void CallNextContender_IfHallEmpty_BeNull()
    {
        _testHall.NextContender().Should().BeNull();
    }
}