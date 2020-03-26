using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterPlayerConnector : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private Dictionary<Player, Character> _playerCharacterLinks = new Dictionary<Player, Character>();

    public void AddPlayerAndCharacter(Player player, Character character)
    {
        print("ADD: " + player.playerID + ", " + character.name);
        _playerCharacterLinks.Add(player, character);
    }

    public Character GetCharacterForPlayer(Player player)
    {
        return _playerCharacterLinks[player];
    }

    public Dictionary<Player, Character> GetPlayerCharacterLinks()
    {
        return _playerCharacterLinks;
    }
}
