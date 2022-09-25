// See https://aka.ms/new-console-template for more information


using princess_choice;

    var hall = new Hall();
    var friend = new Friend();
    var princess = new Princess(friend, hall);
    princess.ChoosePrince();
    var happiness = princess.CountHappy();
    
    using(StreamWriter writetext = new StreamWriter("result.txt"))
    {
        foreach (var contender in friend.PassedContenders)
        {
            writetext.WriteLine(contender + " " + contender.Value());
        }
        writetext.WriteLine("------------------------");
        writetext.WriteLine(happiness);
    }