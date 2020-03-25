using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Fighter
{   

    //Has a higher "_staminaRegenRate" serialized value than other fighters

    protected override void Start()
    {
        base.Start();
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
