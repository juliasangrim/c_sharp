namespace PrincessChoice.DbModel;

/// <summary>
///Entity for attempt. 
/// </summary>
public class PrinceAttemptEntity
{
    public int Id { get; set; }
    public string? AttemptName { get; set; }
    public List<ContenderEntity> Contenders { get; set; }
}