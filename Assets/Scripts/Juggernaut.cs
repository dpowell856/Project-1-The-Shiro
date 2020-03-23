using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggernaut : Fighter
{
    [SerializeField] private float _heathRegenerationAmount;
    [SerializeField] private float _healthRegenerationInterval;

    protected override void Start()
    {
        base.Start();
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
            Heal(_heathRegenerationAmount);
            yield return new WaitForSeconds(_healthRegenerationInterval);
        }
    }
}
