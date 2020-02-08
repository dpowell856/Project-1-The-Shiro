using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public abstract class Damageable : MonoBehaviour
{
    [SerializeField] private float _totalHealth;

    [SerializeField] private Vector2 _velocity;

    private float _health;

    private TextMeshProUGUI _textMesh; 

    void Start()
    {
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
