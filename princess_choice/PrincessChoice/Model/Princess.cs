﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrincessChoice.Strategy;
using PrincessChoice.Writer;

namespace PrincessChoice.Model;

public class Princess : IHostedService
{
    /// <summary>
    /// Princess choose strategy  
    /// </summary>
    private readonly IStrategy _strategy;

    /// <summary>
    /// The hall, where prince wait date with princess.
    /// </summary>
    private readonly IHall _hall;

    private IHostApplicationLifetime _lifetime;

    /// <summary>
    /// Logger.
    /// </summary>
    private ILogger<Princess> _logger;

    /// <summary>
    /// Service for write content in file.
    /// </summary>
    private readonly IWriter _writer;

    public Princess(IHall hall, IWriter writer, IStrategy strategy,
        IHostApplicationLifetime lifetime, ILogger<Princess> logger)
    {
        _hall = hall;
        _writer = writer;
        _lifetime = lifetime;
        _logger = logger;
        _strategy = strategy;
    }

    /// <summary>
    /// Choose the prince by princess.
    /// </summary>
    public void ChoosePrince()
    {
        _hall.CallNextGroup();
        _strategy.BestContender();
    }

    /// <summary>
    /// Count the happiness of a princess after choosing a prince.
    /// </summary>
    /// <returns>Returns 0 - if the princess choose the bad prince,
    /// returns 10 - if the princess did not choose the prince,
    /// returns from 100, 99, ... 51 - if princess chose the 1st good prince,
    /// 2nd good prince ... 50th best prince. </returns>
    public int CountHappy()
    {
        var happiness = 10;
        if (_strategy.BestContenderValue() == null)
        {
            return happiness;
        }

        var princeValue = _strategy.BestContenderValue()!.Value;
        happiness = princeValue > _hall.CountContender() / 2 ? princeValue : 0;
        return happiness;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _lifetime.ApplicationStarted.Register(() =>
        {
            Task.Run(() =>
            {
                try
                {
                    _writer.Delete();
                    ChoosePrince();
                    var happiness = CountHappy();
                    _writer.Write("-------------------------------------");
                    _writer.Write(happiness.ToString());
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
}