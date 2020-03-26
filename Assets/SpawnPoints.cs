using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    private void Start()
    {
        Dictionary<Player, Character> playerCharacters = FindObjectOfType<CharacterPlayerConnector>().GetPlayerCharacterLinks();
        int i = 0;

        foreach (Player player in playerCharacters.Keys)
        {
            Character character = playerCharacters[player];
            GameObject gmobject = Instantiate(character.GetCharacterGameObject(), transform.GetChild(i).position, Quaternion.identity, null);
            gmobject.GetComponent<Fighter>().Instatiate(player.playerID, character.GetSpeed(), character.GetHealth(), character.GetMaxStamina(), character.GetStaminaRegenRate());
            i++;
        }
    }
}
