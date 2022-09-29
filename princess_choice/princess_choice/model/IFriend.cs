namespace princess_choice;

public interface IFriend
{
    /// <summary>
    /// Add contender in list of passed contenders and choose the best of them.
    /// </summary>
    /// <param name="passedContender"> Contender rejected by the princess.</param>
    void AddPassedContender(Contender passedContender);

    /// <summary>
    /// Detect the best contender.
    /// </summary>
    /// <param name="currContender">The contender who is with the princess now.</param>
    /// <returns>Returns true - if contender with the princess is better than last best contender,
    /// otherwise - return false</returns>
    bool IsCurrContenderBest(Contender currContender);

    /// <summary>
    /// Get contender value by name.
    /// </summary>
    /// <param name="contenderName"> Name of contender.</param>
    /// <returns>Returns value of contender with specific name.</returns>
    int GetContenderValue(string contenderName);
}