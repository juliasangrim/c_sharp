namespace princess_choice;

public class Princess
{
    /// <summary>
    /// Princess choose strategy  
    /// </summary>
    private readonly IStrategy _strategy;

    /// <summary>
    /// The prince chosen by the princess
    /// </summary>
    private String? _prince;

    /// <summary>
    /// The princess friend.    
    /// </summary>
    private IFriend _friend;

    public Princess(IFriend friend, IHall hall)
    {
        _friend = friend;
        _strategy = new Strategy(friend, hall);
    }

    /// <summary>
    /// Choose the prince by princess.
    /// </summary>
    public void ChoosePrince()
    {
        _prince = _strategy.BestContender();
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
        if (_prince == null) return happiness;
        var princeValue = _friend.GetContenderValue(_prince);
        happiness = princeValue > IStrategy.MaxMatchScore / 2 ? princeValue : 0;
        return happiness;
    }
}