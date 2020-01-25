using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayers : MonoBehaviour {
    void Awake()
    {
        Debug.Log("Instantiating players");
        Players.Refresh();
        {
            for (int i = 0; i < 4; i++)
            {
                Player player = new Player((Player.ID)i);
                Players.AddPlayer(player);
            }
        }
    }
}