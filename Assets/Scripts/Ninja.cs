using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Fighter
{   
    protected override void Start()
    {
    // Will call a function to regen stamina faster
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
