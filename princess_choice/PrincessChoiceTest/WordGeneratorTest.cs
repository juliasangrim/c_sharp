using AttemptGenerator;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PrincessChoice.Context;

namespace PrincessChoiceTest;

public class WordGeneratorTest
{
    private PostgresDbContext _postgresDbContext;
    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<PostgresDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _postgresDbContext = new PostgresDbContext(options);
    }
    
    [Test]
    public void GenerateAttemptsInDB_Return100Attempts()
    {
        int attemptCount = 100;
        WorldGenerator.Generate(_postgresDbContext, attemptCount);
        var princeAttempts = _postgresDbContext.PrinceAttempt.ToList();
        princeAttempts.Count.Should().Be(attemptCount);
    }
}