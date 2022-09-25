namespace princess_choice;

public class Contender
{
    /// <summary>
    /// Contender name, consist of first name and second name
    /// Name is unique.
    /// </summary>
    private readonly string _name;
    
    /// <summary>
    /// Contender value, show how cool he is.
    /// </summary>
    public int Value { get; }

    public Contender(string name, int value)
    {
        _name = name;
        Value = value;
    }

   
    public override string ToString()
    {
        return _name;
    }
}