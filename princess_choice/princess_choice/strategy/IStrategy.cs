namespace princess_choice;

public interface IStrategy
{
    public const int MaxMatchScore = 100;
    
    /// <summary>
    /// Choose the best contender.
    /// </summary>
    /// <returns>Returns the best contender if he exist,
    /// otherwise return null.</returns>
    Contender? BestContender();
}