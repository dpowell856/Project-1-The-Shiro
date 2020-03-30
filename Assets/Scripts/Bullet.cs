using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _damage; 

    void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsHitDamaging(collision))
        {
            DealDamage(collision, _damage);
            KillBullet();
        }
        else if(IsHitSolid(collision)){
            KillBullet();
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void KillBullet()
    {
        Destroy(gameObject);
    }

    protected abstract bool IsHitDamaging(Collider2D collider);

    protected abstract bool IsHitSolid(Collider2D collider);

    protected abstract void DealDamage(Collider2D collider, float amount);
}
