using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : ProjectileSpawner
{
    [SerializeField] private float _ySpeed, _topYcoordinate, _bottomYcoordinate;

    private float _direction = 1;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(transform.position.y >= _topYcoordinate || transform.position.y <= _bottomYcoordinate)
        {
            _direction = -_direction;
        }
        transform.position += Vector3.up * _ySpeed * _direction;
    }
}
