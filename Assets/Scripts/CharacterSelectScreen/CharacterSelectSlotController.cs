using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectSlotController : MonoBehaviour
{
    private List<Player> _players = new List<Player>();

    public void AddPlayer(Player player)
    {
        _players.Add(player);
        if (_players.Count == transform.childCount)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

}
