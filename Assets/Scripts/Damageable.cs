using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected float _totalHealth;

    protected float _health;

    protected TextMeshProUGUI _textMesh; 

    void Start()
    {
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
        _health = _totalHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
