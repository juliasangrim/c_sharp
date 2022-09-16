// See https://aka.ms/new-console-template for more information


using princess_choice;

    const int countContender = 100;
    var hall = new Hall(countContender);
    var friend = new Friend();
    var princess = new Princess(friend, hall);
    var happiness = princess.CountHappy();
    
    using(StreamWriter writetext = new StreamWriter("result.txt"))
    {
        foreach (var contender in friend.PassedContenders)
        {
            writetext.WriteLine(contender);
        }
        writetext.WriteLine("------------------------");
        writetext.WriteLine(happiness);
    }