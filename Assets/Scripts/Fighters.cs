using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fighters
{
    private static Fighter[] _fighters;

    public static void SetFighters(Fighter[] fighters)
    {
        _fighters = fighters;
    }

    public static Fighter[] GetFighters()
    {
        return _fighters;
    }

    public static Fighter[] GetAliveFighters()
    {
        List<Fighter> fighters = new List<Fighter>();
        foreach(Fighter fighter in _fighters)
        {
            //add if for death once added
            fighters.Add(fighter);
        }
        return fighters.ToArray();
    }
}
