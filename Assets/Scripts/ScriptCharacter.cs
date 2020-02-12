using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charcter", menuName ="Character")]
public class ScriptCharacter : ScriptableObject
{
    [SerializeField] private ID _ID;
    [SerializeField] private GameObject Body;
    [SerializeField] private Sprite Look;


        public enum ID
    {
        char1 = 0,
        char2 = 1,
        char3 = 2,
        char4 = 3,

    }
    public Sprite GetLook()
    {
        return Look;
    }
    public GameObject getBody()
    {
        return Body;
    }
    public ID GetID()
    {
        return _ID;
    }
    
}
