﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    private bool _lit = false;
    [SerializeField] private bool _active;

    private float _timeLeft = 2.0f;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_active){
            _spriteRenderer.color = Color.black;
        } else if (_active && !_lit)
        {
            _spriteRenderer.sprite = sprites[0];
        } else
        {
            _spriteRenderer.sprite = sprites[1];
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
            } else {
                _lit = true;
            }
        }
    }

    // Returns if the fireplace is already active
    public bool isActive()
    {
        return _lit;
    }

    // Returns if the fireplace state is complete
    public bool isDone()
    {
        if (_lit || !_active)
        {
            return true;
        } else
        {
            return false;
        }
    }

    // Sets the fireplaces active state
    public void setActive(bool activate)
    {
        _active = activate;
        _lit = false;
        _timeLeft = 2.0f;
    }
}