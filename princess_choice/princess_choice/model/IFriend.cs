namespace princess_choice;

public interface IFriend
{
    void AddPassedContender(IContender passedContender);
    bool IsCurrContenderBest(IContender currContender);
}