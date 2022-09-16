namespace princess_choice;

public class Friend
{
    public Friend()
    {
        PassedContenders = new List<Contender>();
    }

    public List<Contender> PassedContenders { get; }

    public void AddPassedContender(Contender rejectedContender)
    {
        PassedContenders.Add(rejectedContender);
    }

    public bool IsHeBest(Contender contender, Contender? bestContender)
    {
        if (bestContender == null)
        {
            return true;
        }

        return bestContender.MatchScore < contender.MatchScore;
    }

}