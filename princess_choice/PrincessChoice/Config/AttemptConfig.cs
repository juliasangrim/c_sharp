namespace PrincessChoice.Config;

/// <summary>
/// Class for pass the attempt name to service.
/// </summary>
public class AttemptConfig
{
    public string? AttemptName { get; }

    public AttemptConfig(string? attemptName)
    {
        AttemptName = attemptName;
    }
}