using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightersInitialiser : MonoBehaviour
{
    void Awake()
    {
        Fighters.SetFighters(FindObjectsOfType<Fighter>());
    }
}
