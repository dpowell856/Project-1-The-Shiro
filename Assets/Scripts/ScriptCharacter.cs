using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charcter", menuName ="Character")]
public class ScriptCharacter : ScriptableObject
{
    [SerializeField] private string Name;
    [SerializeField] private string Description;
    [SerializeField] private int Hp;
    [SerializeField] private int Speed;
    [SerializeField] public Sprite Look;

    public Sprite GetLook()
    {
        return Look;
    }
    





}
