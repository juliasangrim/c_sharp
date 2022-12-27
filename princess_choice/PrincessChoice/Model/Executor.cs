using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrincessChoice.Config;
using PrincessChoice.Context;
using PrincessChoice.Writer;

namespace PrincessChoice.Model;

public class Executor : IHostedService
{
    private IHostApplicationLifetime _lifetime;

    /// <summary>
    /// Logger.
    /// </summary>
    private ILogger<Princess> _logger;

    /// <summary>
    /// Service for write content in file.
    /// </summary>
    private readonly IWriter _writer;

    private AttemptConfig _attemptConfig;

    /// <summary>
    /// Princess, who chose prince.
    /// </summary>
    private Princess _princess;

    /// <summary>
    /// PostgresDB connection.
    /// </summary>
    private PostgresDbContext _postgresDb;

    public Executor(IWriter writer, Princess princess, AttemptConfig config, PostgresDbContext dbContext,
        IHostApplicationLifetime lifetime, ILogger<Princess> logger)
    {
        _writer = writer;
        _princess = princess;
        _attemptConfig = config;
        _postgresDb = dbContext;
        _lifetime = lifetime;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _lifetime.ApplicationStarted.Register(() =>
        {
            Task.Run(async () =>
            {
                try
                {
                    _writer.Delete();
                    var attemptName = _attemptConfig.AttemptName;
                    if (attemptName == null)
                    {
                        await RunAllAttempt();
                    }
                    else
                    {
                        await RunAttempt(attemptName);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled exception!");
                }
                finally
                {
                    _lifetime.StopApplication();
                }
            }, cancellationToken);
        });
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Run all attempts in db.
    /// </summary>
    private async Task RunAllAttempt()
    {
        var attempts = await _postgresDb.PrinceAttempt.Include(c => c.Contenders).ToListAsync();
        var sum = 0;
        foreach (var attempt in attempts) {
            sum +=  await _princess.CountHappy(attempt.AttemptName);
        }
        _writer.Write($"Average happiness for {attempts.Count} attempts: {(double)sum / attempts.Count}");
    }

    /// <summary>
    /// Run attempt with specified name.
    /// </summary>
    /// <param name="attemptName">Attempt name.</param>
    private async Task RunAttempt(string attemptName)
    {
        var happiness = await _princess.CountHappy(attemptName);
        _writer.Write($"Happiness for {attemptName} attempts: {happiness}");
    }
}