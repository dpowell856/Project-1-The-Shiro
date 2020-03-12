using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggernaut : Fighter
{   
    protected override void PassiveAbillity()
    {
        StartCoroutine(RegenHealth());
	}

    protected override void Update()
    {
        base.Update();

    }

    protected override void UseAbillity()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator RegenHealth()
    {
        while(_health > 0)
        {
            if(_health < 100)
            {
                yield return new WaitForSeconds(2);
                _health += 1;
                print("regenerated");
            }
            else
            {
                yield return new WaitForSeconds(2);
                print("not regenerated");
			}
        }
    }
}
