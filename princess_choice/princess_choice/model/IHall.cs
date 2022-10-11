namespace princess_choice.model;

public interface IHall
{
    /// <summary>
    /// Get next waiting contenders.
    /// </summary>
    /// <returns>Returns next waiting contender if exist, otherwise return null.</returns>
    Contender? NextContender();

    /// <summary>
    /// Get amount of contenders.
    /// </summary>
    /// <returns>Returns amount of contenders in list.</returns>
    int CountContender();

    /// <summary>
    /// Generate new group of 100 contenders.
    /// </summary>
    void CallNextGroup();
}