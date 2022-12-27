using PrincessChoice.DbModel;
using PrincessChoice.Model;

namespace PrincessChoice.Mapper;

public static class ContendersListMapper
{
    /// <summary>
    /// Mapping list of db entities to app entities.
    /// </summary>
    /// <param name="contenderEntities">List of db entities.</param>
    /// <returns>List of app entities.</returns>
    public static List<Contender> Map(List<ContenderEntity> contenderEntities)
    {
        return contenderEntities.OrderBy(ce => ce.SequenceNumber)
            .Select(ce => new Contender(ce.Name, ce.Value)).ToList();
    }

    /// <summary>
    /// Mapping list of app entities to db entities.
    /// </summary>
    /// <param name="contenders">List of app entities.</param>
    /// <returns>List of db entities.</returns>
    public static List<ContenderEntity> Map(List<Contender> contenders)
    {
        var seqNum = 0;
        return contenders.Select(c => new ContenderEntity()
        {
            Name = c.Name,
            Value = c.Value,
            SequenceNumber = seqNum++
        }).ToList();
    }
}