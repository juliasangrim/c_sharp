namespace princess_choice;

public class Contender
{
    /// <summary>
    /// Contender name, consist of first name and second name
    /// Name is unique.
    /// </summary>
    private string _name;
    
    /// <summary>
    /// Contender value, show how cool he is.
    /// </summary>
    private int _value;

    public Contender(string name, int value)
    {
        _value = value;
        _name = name;
    }

    public int Value
    {
        get => _value;
    }

    public override string ToString()
    {
        return _name;
    }
}