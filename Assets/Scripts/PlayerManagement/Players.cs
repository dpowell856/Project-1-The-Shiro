using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Players {

    private static List<Player> _players = new List<Player>();

    public static void Refresh()
    {
        _players = new List<Player>();
    }

    public static List<Player> GetPlayers()
    {
        return _players;
    }

    public static Player GetPlayer(Player.ID playerID)
    {
        return _players[(int)playerID];
    }

    public static void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    /*public static void RemovePlayer(Player player)
    {
        _players[(int)player.GetID()] = null;
    }*/
}