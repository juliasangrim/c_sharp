using Microsoft.EntityFrameworkCore;
using PrincessChoice.Context;
using PrincessChoice.Mapper;

namespace PrincessChoice.Model;

public class HallDb : IHall
{
    /// <summary>
    /// List of all waiting contenders.
    /// </summary>
    protected List<Contender> _allContenders;

    /// <summary>
    /// Enumerator for list of waiting contenders.
    /// </summary>
    protected List<Contender>.Enumerator _enumerator;

    /// <summary>
    /// Connection to PostgresDB.
    /// </summary>
    private PostgresDbContext _postgresDb;

    public HallDb(PostgresDbContext postgresDb)
    {
        _postgresDb = postgresDb;
        _allContenders = new List<Contender>();
        _enumerator = _allContenders.GetEnumerator();
    }

    /// <summary>
    /// Generate new group of 100 contenders.
    /// </summary>
    public void CallNextGroup(string? attemptName)
    {
        if (attemptName != null)
        {
            var princeAttemptEntity = _postgresDb.PrinceAttempt
                .Include(c => c.Contenders)
                .FirstOrDefault(a => a.AttemptName == attemptName);
            if (princeAttemptEntity == null)
            {
                throw new ArgumentException($"No attempt in db with this name: {attemptName}!");
            }

            _allContenders = ContendersListMapper.Map(princeAttemptEntity.Contenders);
        }
        else
        {
            throw new ArgumentException("Attempt name should be not null!");
        }
        _enumerator = _allContenders.GetEnumerator();
    }

    /// <summary>
    /// Get next waiting contenders.
    /// </summary>
    /// <returns>Returns next waiting contender if exist, otherwise return null.</returns>
    public Contender? NextContender()
    {
        return _enumerator.MoveNext() ? _enumerator.Current : null;
    }
    
    /// <summary>
    /// Get amount of contenders.
    /// </summary>
    /// <returns>Returns amount of contenders in list.</returns>
    public int CountContender()
    {
        return _allContenders.Count;
    }
}