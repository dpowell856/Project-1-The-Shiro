using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActivePlayers {
    private static Player[] _players;

    static ActivePlayers()
    {
        Reset();
    }

    public static void Reset()
    {
        _players = new Player[4];
    }

    public static Player[] GetPlayers()
    {
        return _players;
    }

    public static Player GetPlayer(Player.ID playerID)
    {
        return _players[(int)playerID];
    }

    public static void AddPlayer(Player player)
    {
        _players[(int)player.playerID] = player;
    }

    public static int Count()
    {
        int count = 0;
        foreach (var player in _players)
            if (player != null)
                count++;
        return count;
    }
}