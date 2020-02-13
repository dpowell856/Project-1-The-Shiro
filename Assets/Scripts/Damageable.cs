using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected float _totalHealth;

    [SerializeField] protected Vector3 _velocity;

    protected float _health;

    protected TextMeshProUGUI _textMesh; 

    void Start()
    {
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    protected void TakeDamage(float damage)
    {
        _health -= damage;
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
