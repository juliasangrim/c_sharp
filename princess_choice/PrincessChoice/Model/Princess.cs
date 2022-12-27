using Microsoft.Extensions.Logging;
using PrincessChoice.Strategy;

namespace PrincessChoice.Model;

public class Princess
{
    private const int HappinessIfAlone = 10;

    /// <summary>
    /// Princess choose strategy  
    /// </summary>
    private readonly IStrategy _strategy;

    /// <summary>
    /// The hall, where prince wait date with princess.
    /// </summary>
    private readonly IHall _hall;

    /// <summary>
    /// Logger.
    /// </summary>
    private ILogger<Princess> _logger;

    public Princess(IHall hall, IStrategy strategy, ILogger<Princess> logger)
    {
        _hall = hall;
        _logger = logger;
        _strategy = strategy;
    }

    /// <summary>
    /// Count the happiness of a princess after choosing a prince.
    /// </summary>
    /// <returns>Returns 0 - if the princess choose the bad prince,
    /// returns 10 - if the princess did not choose the prince,
    /// returns from 100, 99, ... 51 - if princess chose the 1st good prince,
    /// 2nd good prince ... 50th best prince. </returns>
    public async Task<int> CountHappy(string? attemptName)
    {
        await _hall.CallNextGroup(attemptName);
        _strategy.BestContender();
        var happiness = HappinessIfAlone;
        if (_strategy.BestContenderValue() == null)
        {
            return happiness;
        }

        var princeValue = _strategy.BestContenderValue()!.Value;
        happiness = princeValue > _hall.CountContender() / 2 ? princeValue : 0;
        return happiness;
    }
}