namespace princess_choice.strategy;

public interface IStrategy
{
    /// <summary>
    /// Choose the best contender.
    /// </summary>
    /// <returns>Returns the best contender if he exist,
    /// otherwise return null.</returns>
    void BestContender();

    /// <summary>
    /// Get best contender value;
    /// </summary>
    /// <returns>Returns best contender value, if he exist,
    /// otherwise return null.</returns>
    int? BestContenderValue();
}