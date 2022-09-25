namespace princess_choice;

public class Friend
{
    /// <summary>
    /// The list of passed contenders.
    /// </summary>
    public List<Contender> PassedContenders { get; }

    public Friend()
    {
        PassedContenders = new List<Contender>();
    }

    /// <summary>
    /// Add contender in list of passed contenders.
    /// </summary>
    /// <param name="passedContender"> Contender rejected by the princess.</param>
    public void AddPassedContender(Contender passedContender)
    {
        PassedContenders.Add(passedContender);
    }
    
    /// <summary>
    /// Detect the best contender.
    /// </summary>
    /// <param name="currContender">The contender who is with the princess now.</param>
    /// <param name="lastBestContender">The best contender of all the has passed</param>
    /// <returns>Returns true - if contender with the princess is better than last best contender,
    /// otherwise - return false</returns>
    public bool IsCurrContenderBest(Contender currContender, Contender? lastBestContender)
    {
        if (lastBestContender == null)
        {
            return true;
        }
        
        if (!PassedContenders.Contains(lastBestContender))
        {
            throw new ArgumentException("Contender not in list of passed contenders!");
        }
        
        return lastBestContender.Value < currContender.Value;
    }
}