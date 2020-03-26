using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGspawnPlayer : MonoBehaviour
{
    [SerializeField] private Character _character;

    [SerializeField] private bool _useMouseAndKeyboard;

    // Start is called before the first frame update
    void Start()
    {
        GameObject fighterObj = Instantiate(_character.GetCharacterGameObject());
        fighterObj.GetComponent<Fighter>().Instatiate(Player.ID.player0, _character.GetSpeed(), _character.GetHealth(), _character.GetMaxStamina(), _character.GetStaminaRegenRate(), _useMouseAndKeyboard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
