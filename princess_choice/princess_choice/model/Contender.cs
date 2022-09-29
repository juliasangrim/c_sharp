namespace princess_choice;

public class Contender
{
    /// <summary>
    /// Contender name, consist of first name and second name
    /// Name is unique.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Contender value, show how cool he is.
    /// </summary>
    public int Value { get; }

    public Contender(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override string ToString()
    {
        return Name;
    }
}