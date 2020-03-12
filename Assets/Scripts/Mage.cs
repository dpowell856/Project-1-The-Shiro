using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Fighter
{   
    protected override void Start()
    {
        this._health = 50;
        // Will call a function which will enable mage to light fires instantly
	}

    protected override void Update()
    {
        base.Update();

    }

    protected override void UseAbillity()
    {
        throw new System.NotImplementedException();
    }
}
