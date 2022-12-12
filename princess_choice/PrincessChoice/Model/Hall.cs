﻿using PrincessChoice.Generator;

namespace PrincessChoice.Model;

public class Hall : IHall
{
    /// <summary>
    /// List of all waiting contenders.
    /// </summary>
    protected List<Contender> _allContenders;

    /// <summary>
    /// Enumerator for list of waiting contenders.
    /// </summary>
    protected List<Contender>.Enumerator _enumerator;

    public Hall()
    {
        _allContenders = new List<Contender>();
        _enumerator = _allContenders.GetEnumerator();
    }

    /// <summary>
    /// Generate new group of 100 contenders.
    /// </summary>
    public virtual void CallNextGroup(string? attemptName)
    {
        _allContenders = ContenderGenerator.GenerateContenders();
        _enumerator = _allContenders.GetEnumerator();
    }

    /// <summary>
    /// Get next waiting contenders.
    /// </summary>
    /// <returns>Returns next waiting contender if exist, otherwise return null.</returns>
    public Contender? NextContender()
    {
        return _enumerator.MoveNext() ? _enumerator.Current : null;
    }
    
    /// <summary>
    /// Get amount of contenders.
    /// </summary>
    /// <returns>Returns amount of contenders in list.</returns>
    public int CountContender()
    {
        return _allContenders.Count;
    }
}