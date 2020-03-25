using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    private bool _lit = false;
    private bool _active;

    private float _timeLeft = 0.5f;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_active){
            _spriteRenderer.color = new Color(0, 0, 0);
        } else if (_active && !_lit)
        {
            _spriteRenderer.color = new Color(255, 255, 255);
        } else
        {
            _spriteRenderer.color = new Color(255, 0, 0);
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
        _timeLeft = 0.5f;
    }
}