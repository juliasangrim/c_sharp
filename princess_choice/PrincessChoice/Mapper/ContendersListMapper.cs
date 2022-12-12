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
        var listMapContenders = new List<Contender>(contenderEntities.Count);
        foreach (var contenderEntity in contenderEntities)
        {
            var contender = new Contender(contenderEntity.Name, contenderEntity.Value);
            if (contenderEntity.SequenceNumber < contenderEntities.Count)
            {
                listMapContenders.Insert(contenderEntity.SequenceNumber, contender);
            }
            else
            {
                throw new ArgumentException("List of contenders not full.");
            }
        }

        return listMapContenders;
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