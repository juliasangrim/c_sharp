namespace princess_choice;

public interface IHall
{
    IContender? NextContender();
    int CountContender();
}