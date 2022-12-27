namespace PrincessChoice.Model;

public interface IFriend
{
    /// <summary>
    /// Add contender in list of passed contenders and choose the best of them.
    /// </summary>
    /// <param name="passedContender"> Contender rejected by the princess.</param>
    void AddPassedContender(Contender passedContender);
    
    /// <summary>
    /// Delete all contenders in friend list.
    /// </summary>
    void ForgetAllPastContenders();

    /// <summary>
    /// Detect the best contender.
    /// </summary>
    /// <param name="currContender">The contender who is with the princess now.</param>
    /// <returns>Returns true - if contender with the princess is better than last best contender,
    /// otherwise - return false</returns>
    bool IsCurrContenderBest(Contender currContender);

    /// <summary>
    /// Friend track, who from passed contenders are best. This method allow you to remember contender if he better than other
    /// passed contenders.
    /// </summary>
    /// <param name="currContender">Contender, whom we want to remember.</param>
    /// <exception cref="ArgumentException">Throws when contender with that name not found.</exception>
    void RememberContenderIfBest(Contender currContender);
}