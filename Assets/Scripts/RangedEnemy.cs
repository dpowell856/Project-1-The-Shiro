using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyFighter
{
    [SerializeField] private float _shootingRange, _shootingInterval;

    private Gun _gun;

    private float _timeLastShot;

    protected override void Awake()
    {
        base.Awake();
        _gun = GetComponentInChildren<Gun>();
    }

    protected override void Start()
    {
        base.Start();
        _timeLastShot = Time.time;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (_rangeFromPlayer > Vector2.Distance(_closetsFighter.position, transform.position) - _shootingRange)
        {
            if (Time.time - _timeLastShot > _shootingInterval)
            {
                Shoot();
                _timeLastShot = Time.time;
            }
        }
    }

    private void Shoot()
    {
        _gun.Shoot();
    }
}
