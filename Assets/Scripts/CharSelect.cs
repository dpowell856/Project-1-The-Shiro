using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharSelect : MonoBehaviour
    
{

    [SerializeField] private GameObject Char1;
    [SerializeField] private GameObject Char2;
    [SerializeField] private GameObject Char3;
    //[SerializeField] private GameObject Spawn;
    private Vector3 CharPos;
    private Vector3 SPos;
    private Vector3 OffScreen;
    private int num = 0;
    private SpriteRenderer Char1Render, Char2Render, Char3Render, SpawnRender;
    public TextMeshProUGUI Text1, Text2, Text3;
    //private Sprite CharSprite;
    private SpriteRenderer[] RenderList = new SpriteRenderer[3];
    private GameObject[] CharList = new GameObject[3];
    //[SerializeField] private ScriptableObject[] Charlist2 = new ScriptableObject[3];

    private void Awake()
    {
        CharPos = Char1.transform.position;
        OffScreen = Char2.transform.position;
        Char1Render = Char1.GetComponent<SpriteRenderer>();
        Char2Render = Char1.GetComponent<SpriteRenderer>();
        Char3Render = Char1.GetComponent<SpriteRenderer>();
        //SpawnRender = Spawn.GetComponent<SpriteRenderer>();
       
    }
    private void Start()
    {
        RenderList[0] = Char1Render;
        RenderList[1] = Char2Render;
        RenderList[2] = Char3Render;
        CharList[0] = Char1;
        CharList[1] = Char2;
        CharList[2] = Char3;
    }



    public void Update()
    {
        Text1.text = CharList[num].GetComponentInChildren<CharInfo>().Name;
        Text2.text = CharList[num].GetComponentInChildren<CharInfo>().Description;
        Text3.text = "Hp " + CharList[num].GetComponentInChildren<CharInfo>().Hp + "\nStr " + CharList[num].GetComponentInChildren<CharInfo>().Str + "\nDex " + CharList[num].GetComponentInChildren<CharInfo>().Dex + "\nInt " + CharList[num].GetComponentInChildren<CharInfo>().Int;
        
    }

    public void NextChar()
    {
        RenderList[num].enabled = false;
        CharList[num].transform.position = OffScreen;
        if (num >= 2)
        {
            NumReset();
        }
        else
        {
            num++;
        }
        RenderList[num].enabled = true;
        CharList[num].transform.position = CharPos;
        
    }

    public void PreviousChar()
    {
        RenderList[num].enabled = false;
        CharList[num].transform.position = OffScreen;
        if (num <= 0)
        {
            NumReset();
        }
        else
        {
            num--;
        }
        RenderList[num].enabled = true;
        CharList[num].transform.position = CharPos;
      
    }

    public void NumReset()
    {
        if (num >= 2)
        {
            num = 0;
        }
        else
        {
            num = 2;
        }
    }

}
