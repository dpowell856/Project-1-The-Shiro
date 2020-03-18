using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : Fighter
{   
    protected override void PassiveAbillity()
    {
        this._health = 150;
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
