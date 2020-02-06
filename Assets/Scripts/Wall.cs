using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _selfDestructTime;
    [SerializeField] private float _repairTime;
    [SerializeField] private float _totalLife;

    private float _life;

    private TextMeshProUGUI _lifeText;

    void Awake()
    {
        _lifeText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        _life = _totalLife;
    }

    void Update()
    {
        ShowCurrentLife();
    }

    private void FixedUpdate()
    {
        _life -= _totalLife * (Time.fixedDeltaTime / _selfDestructTime);
        if(_life <= 0)
        {
            Break();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _life += _totalLife * (Time.fixedDeltaTime / _repairTime);
            if(_life > _totalLife)
            {
                _life = _totalLife;
            }
        }
    }

    private void ShowCurrentLife()
    {
        _lifeText.text = Mathf.CeilToInt(_life) + " / " + _totalLife;
    }

    private void Break()
    {
        Destroy(gameObject);
    }
}
