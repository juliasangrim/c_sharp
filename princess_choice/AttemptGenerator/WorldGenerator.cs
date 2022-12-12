namespace AttemptGenerator;

using PrincessChoice.Context;
using PrincessChoice.DbModel;
using PrincessChoice.Generator;
using PrincessChoice.Mapper;

public static class WorldGenerator
{
    /// <summary>
    /// Generate attempts in db.
    /// </summary>
    /// <param name="db">Db, where attempts are generated.</param>
    /// <param name="attemptCount">Amount of generating attempts.</param>
    public static void Generate(PostgresDbContext db, int attemptCount)
    {
        for (int i = 0; i < attemptCount; i++)
        {
            var contenders = ContenderGenerator.GenerateContenders();
            var attempt = new PrinceAttemptEntity()
            {
                AttemptName = i.ToString(),
                Contenders = ContendersListMapper.Map(contenders)
            };
            db.PrinceAttempt.Add(attempt);
        }
        db.SaveChanges();
    }
}