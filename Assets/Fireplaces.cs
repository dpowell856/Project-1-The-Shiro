using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplaces : MonoBehaviour
{
    private Fireplace[] _fireplaces;

    void Start()
    {
        _fireplaces = GetComponentsInChildren<Fireplace>();
    }

    void Update()
    {
        if (IsAllActiveFireplacesLit())
        {
            StartNextWave();
        }
    }

    private bool IsAllActiveFireplacesLit()
    {
        //loop through actiavted fireplaces and check if their all lit return true
    }

    private void SartNextWave()
    {

    }
}
