using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharSelect : MonoBehaviour
    
{

    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;
    private Vector3 CharPos;
    private Vector3 OffScreen;
    private int num = 1;
    private SpriteRenderer Char1Render, Char2Render, Char3Render;
    public TextMeshProUGUI Text1, Text2, Text3;


    private void Awake()
    {
        CharPos = Char1.transform.position;
        OffScreen = Char2.transform.position;
        Char1Render = Char1.GetComponent<SpriteRenderer>();
        Char2Render = Char1.GetComponent<SpriteRenderer>();
        Char3Render = Char1.GetComponent<SpriteRenderer>();
        
    }
    public void Update()
    {
        if (num == 1)
        {
            Text1.text = Char1.GetComponentInChildren<CharInfo>().Name;
            Text2.text = Char1.GetComponentInChildren<CharInfo>().Description;
            Text3.text = "Hp " + Char1.GetComponentInChildren<CharInfo>().Hp + "\nStr " + Char1.GetComponentInChildren<CharInfo>().Str + "\nDex " + Char1.GetComponentInChildren<CharInfo>().Dex + "\nInt " + Char1.GetComponentInChildren<CharInfo>().Int;
        }
        else if (num == 2)
        {
            Text1.text = Char2.GetComponentInChildren<CharInfo>().Name;
            Text2.text = Char2.GetComponentInChildren<CharInfo>().Description;
            Text3.text = "Hp " + Char2.GetComponentInChildren<CharInfo>().Hp + "\nStr " + Char2.GetComponentInChildren<CharInfo>().Str + "\nDex " + Char2.GetComponentInChildren<CharInfo>().Dex + "\nInt " + Char2.GetComponentInChildren<CharInfo>().Int;
        }
        else if (num == 3)
        {
            Text1.text = Char3.GetComponentInChildren<CharInfo>().Name;
            Text2.text = Char3.GetComponentInChildren<CharInfo>().Description;
            Text3.text = "Hp " + Char3.GetComponentInChildren<CharInfo>().Hp + "\nStr " + Char3.GetComponentInChildren<CharInfo>().Str + "\nDex " + Char3.GetComponentInChildren<CharInfo>().Dex + "\nInt " + Char3.GetComponentInChildren<CharInfo>().Int;
        }
            
    }




    public void NextChar()
    {
        switch (num)
        {

            case 1:
                Char1Render.enabled = false;
                Char1.transform.position = OffScreen;
                Char2Render.enabled = true;
                Char2.transform.position = CharPos;
                num++;
                break;
            case 2:
                Char2Render.enabled = false;
                Char2.transform.position = OffScreen;
                Char3Render.enabled = true;
                Char3.transform.position = CharPos;
                num++;
                break;
            case 3:
                Char3Render.enabled = false;
                Char3.transform.position = OffScreen;
                Char1Render.enabled = true;
                Char1.transform.position = CharPos;
                NumReset();
                break;
            default:
                NumReset();
                break;

        }

    }

    public void NumReset()
    {
        if (num >= 3)
        {
            num = 1;
        }
        else
        {
            num = 3;
        }
    }

    public void PreviousChar()
    {
        switch (num)
        {

            case 1:
                Char1Render.enabled = false;
                Char1.transform.position = OffScreen;
                Char3Render.enabled = true;
                Char3.transform.position = CharPos;
                NumReset();
                break;
            case 2:
                Char2Render.enabled = false;
                Char2.transform.position = OffScreen;
                Char1Render.enabled = true;
                Char1.transform.position = CharPos;
                num--;
                break;
            case 3:
                Char3Render.enabled = false;
                Char3.transform.position = OffScreen;
                Char2Render.enabled = true;
                Char2.transform.position = CharPos;
                num--;
                break;
            default:
                NumReset();
                break;

        }
    }
}
