using Microsoft.EntityFrameworkCore;
using PrincessChoice.DbModel;

namespace PrincessChoice.Context;

public class PostgresDbContext : DbContext
{
    public DbSet<ContenderEntity> Contender => Set<ContenderEntity>();
    public DbSet<PrinceAttemptEntity> PrinceAttempt => Set<PrinceAttemptEntity>();

    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) :
        base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
}