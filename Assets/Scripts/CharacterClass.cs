using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterClass { // Needs to be properly filled
    Ninja,
    Samurai
}

public class Character : ScriptableObject
{
    [SerializeField] private CharacterClass _characterClass;

    [SerializeField] private Sprite _characterSprite;

    [SerializeField] private float _speed;

    [SerializeField] private float _dodgeRefreshRate;

    [SerializeField] private Sprite _bulletSprite;

    [SerializeField] private float _bulletInterval;

    [SerializeField] private float _bulletDamage;
}