using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplaces : MonoBehaviour
{
    private Fireplace[] _fireplaces;
    private int _wave = 0;

    void Start()
    {
        _fireplaces = GetComponentsInChildren<Fireplace>();
    }

    void Update()
    {
        if (IsAllActiveFireplacesLit() || _wave == 0)
        {
            StartNextWave();
        }
    }

    private bool IsAllActiveFireplacesLit()
    {
        bool allActive = true;
        for(int i = 0; i < _fireplaces.Length; i++)
        {
            if (_fireplaces[i].isDone() == false){ allActive = false; }    
        }

        return allActive;
        
        //loop through activated fireplaces and check if their all lit return true
    }

    private void StartNextWave()
    {
        for (int i = 0; i < _fireplaces.Length; i++)
        {
            _fireplaces[i].setActive(false);
        }

        int _random = Random.Range(4, 7);
        Debug.Log("Amount: " + _random);        

        for (int i = 0; i < _random; i++)
        {
            int _activateFire = Random.Range(0, _fireplaces.Length);
            Debug.Log("Random " +_activateFire);
            while (_fireplaces[_activateFire].isActive() == true)
            {
                _activateFire = Random.Range(0, _fireplaces.Length);
                Debug.Log("Repeat: " + _activateFire);
            }
            _fireplaces[_activateFire].setActive(true);
        }
        _wave += 1;
    }
}
