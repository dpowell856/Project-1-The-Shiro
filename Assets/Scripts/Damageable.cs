using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Damageable : MonoBehaviour
{
    [SerializeField] protected float _totalHealth;

    protected float _health;

    protected virtual void Awake(){}

    protected virtual void Start()
    {
        _health = _totalHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
