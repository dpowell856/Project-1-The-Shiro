using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType { // Needs to be properly filled
    Ninja,
    Samurai,
    Juggernaut,
    Mage
}

[CreateAssetMenu(fileName = "New Charcter", menuName = "Character")]
public class Character : ScriptableObject
{
    [SerializeField] private CharacterType _characterType;

    [SerializeField] private Sprite _characterSprite;

    [SerializeField] private GameObject _characterGameObject;

    [SerializeField] private float _speed;

    [SerializeField] private float _health;

    [SerializeField] private float _maxStamina;

    [SerializeField] private float _staminaRegenRate;

    public CharacterType getCharacterType()
    {
        return _characterType;
    }

    public Sprite GetSprite()
    {
        return _characterSprite;
    }
    
    public GameObject GetCharacterGameObject()
    {
        return _characterGameObject;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float GetHealth()
    {
        return _health;
    }

    public float GetMaxStamina()
    {
        return _maxStamina;
    }

    public float GetStaminaRegenRate()
    {
        return _staminaRegenRate;
    }
}