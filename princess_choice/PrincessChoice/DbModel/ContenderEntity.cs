namespace PrincessChoice.DbModel;

/// <summary>
///DTO for contender. 
/// </summary>
public class ContenderEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Value { get; set; }
    public int SequenceNumber { get; set; }
}