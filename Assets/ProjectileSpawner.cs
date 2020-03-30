using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

    [SerializeField] private float _interval, _damage, _speed;

    private bool _active = false;

    private float _time;

    private void Start()
    {
        _time = Time.time;
    }

    protected virtual void FixedUpdate() { }

    protected virtual void Update()
    {
        if (_active)
        {
            if (Time.time - _time > _interval)
            {
                ShootProjectile();
                _time = Time.time;
            }
        }
    }

    private void ShootProjectile()
    {
        GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation, null);
        projectile.GetComponent<Projectile>().Instantiate(_speed, _damage);
    }

    public void SetActive(bool isActive)
    {
        _active = isActive;
    }

    public bool IsActive()
    {
        return _active;
    }
}
