using princess_choice.strategy;

namespace princess_choice.model;

public class Princess
{
    /// <summary>
    /// Princess choose strategy  
    /// </summary>
    private readonly IStrategy _strategy;

    /// <summary>
    /// The hall, where prince wait date with princess.
    /// </summary>
    private readonly IHall _hall;

    public Princess(IFriend friend, IHall hall)
    {
        _hall = hall;
        _strategy = new Strategy(friend, hall);
    }

    /// <summary>
    /// Choose the prince by princess.
    /// </summary>
    public void ChoosePrince()
    {
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
}