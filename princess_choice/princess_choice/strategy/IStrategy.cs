namespace princess_choice;

public interface IStrategy
{
    public const int MaxMatchScore = 100;
    IContender? BestContender();
}