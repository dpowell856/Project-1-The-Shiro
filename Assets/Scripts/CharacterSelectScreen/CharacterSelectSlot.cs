using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSelectSlot : MonoBehaviour
    
{
    [SerializeField] private Character[] _characters;

    private CircularArray<Character> _charactersCircularArray;

    private Player _player;

    [SerializeField] private Player.ID _playerID;

    private Image _image;

    private TextMeshProUGUI _statsText;
    private TextMeshProUGUI _nameText;

    private bool _locked = false;

    private void Awake()
    {
        foreach (Image image in GetComponentsInChildren<Image>())
        {
            if (image.name == "CharacterImage")
            {
                _image = image;
                break;
            }
        }

        foreach(TextMeshProUGUI text in GetComponentsInChildren<TextMeshProUGUI>())
        {
            if(text.name == "Name")
            {
                _nameText = text;
            }
            else if(text.name == "Stats")
            {
                _statsText = text;
            }
        }
    }

    private void Start()
    {
        _charactersCircularArray = new CircularArray<Character>(_characters);
        print("PlayerID: " + _playerID);
        _player = Players.GetPlayer(_playerID);
        print("Fetched PlayerID: " + _player.playerID);
    }

    private void Update()
    {
        if (!_locked)
        {
            if (_player.GetAction(Action.Dash))
            {
                LockInCharacter();
                _locked = true;
            }
            else if(_player.GetAction(Action.Interact)){
                DisplayNextCharacter();
            }
            else if (_player.GetAction(Action.Shoot))
            {
                DisplayPreviousCharacter();
            }
        }
    }

    private void LockInCharacter()
    {
        FindObjectOfType<CharacterPlayerConnector>().AddPlayerAndCharacter(_player, _charactersCircularArray.Current());
        transform.GetComponentInParent<CharacterSelectSlotController>().AddPlayer(_player);
        _image.color = Color.gray;
    }

    private void SetPlayer(Player player)
    {
        _player = player;
    }

    public void DisplayNextCharacter()
    {
        SwapCharacter(_charactersCircularArray.PeakNext());
    }

    public void DisplayPreviousCharacter(){
        SwapCharacter(_charactersCircularArray.PeakPrevious());
    }

    private void SwapCharacter(Character character)
    {
        _image.sprite = character.GetSprite();
        _nameText.text = System.Enum.GetName(typeof(CharacterType), character.getCharacterType());
        _statsText.text = "Speed: " + character.GetSpeed() * 100
            + "                 Health :" + character.GetHealth()
            + "                 Stamina :" + character.GetMaxStamina()
            + "                 Stamina Regen Rate :" + character.GetStaminaRegenRate() * 10;
    }
}