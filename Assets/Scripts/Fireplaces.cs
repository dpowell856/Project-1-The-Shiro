using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fireplaces : MonoBehaviour
{
    private Fireplace[] _fireplaces;
    private int _wave = 0;

    private TextMeshProUGUI _announcementText;

    void Start()
    {
        _fireplaces = GetComponentsInChildren<Fireplace>();
        _announcementText = GetComponentInChildren<TextMeshProUGUI>();
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
        _announcementText.text = "Round " + (_wave + 1);
        
        for (int i = 0; i < _fireplaces.Length; i++)
        {
            _fireplaces[i].setActive(false);
        }

        int _random = Random.Range(4, 6);  

        for (int i = 0; i < _random; i++)
        {
            int _activateFire = Random.Range(0, _fireplaces.Length);
            while (_fireplaces[_activateFire].isActive() == true)
            {
                _activateFire = Random.Range(1, _fireplaces.Length);
            }
            _fireplaces[_activateFire].setActive(true);
        }
        _wave += 1;
    }
}