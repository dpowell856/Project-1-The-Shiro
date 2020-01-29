using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    private float _random;
    private float _range = 2.0f;
    private float _distance;
    private bool _activated;
    private bool _lit = false;

    private SpriteRenderer _sr;
    private Vector2 _playerPosition;
    private Vector2 _position;
    [SerializeField] private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _random = Random.Range(0.0f, 2.0f);
        if (_random < 1.0f)
        {
            _activated = false;
        } else
        {
            _activated = true;
        }
        _sr = this.GetComponent<SpriteRenderer>();
        _position = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_activated == true)
        {
            _sr.color = new Color(255, 230, 210);
            _distance = Vector2.Distance(_player.transform.position, _position);
            if(_distance < _range)
            {
                _lit = true;
            }
        }
        else if(_activated == false)
        {
            _sr.color = new Color(0, 0, 0);
        }

        if (_lit == true)
        {
            _sr.color = new Color(255, 0, 0);
        }
    }
}
