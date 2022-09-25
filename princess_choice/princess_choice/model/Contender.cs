namespace princess_choice;

public class Contender : IContender
{
    /// <summary>
    /// Contender name, consist of first name and second name
    /// Name is unique.
    /// </summary>
    private readonly string _name;

    /// <summary>
    /// Contender value, show how cool he is.
    /// </summary>
    public int _value;

    public Contender(string name, int value)
    {
        _name = name;
        _value = value;
    }
    
    public override string ToString()
    {
        return _name;
    }

    public int Value()
    {
        return _value;
    }
}