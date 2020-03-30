using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcer : ProjectileSpawner
{
    [SerializeField] private float _MaxDegrees, _MinDegress, _rotationSpeed;

    private float _directionOfRotation = 1;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(transform.rotation.eulerAngles.z >= _MaxDegrees || transform.rotation.eulerAngles.z <= _MinDegress)
        {
            _directionOfRotation = -_directionOfRotation;
        }
        transform.Rotate(Vector3.forward * _rotationSpeed * _directionOfRotation);
    }
}
