using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : ProjectileSpawner
{
    [SerializeField] private float _spinSpeed;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        transform.Rotate(Vector3.forward * _spinSpeed);
    }
}
