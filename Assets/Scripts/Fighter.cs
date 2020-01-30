using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player _player;

    private Vector2 _axisVector;

    void Start()
    {
        _player = Players.GetPlayer(Player.ID.player0);
    }

    void Update()
    {
        // GetAction is a boolean that returns true when the button is down
        if (_player.GetAction(Action.Shoot))
        {
            print("SHOOT BUTTON HAS BEEN PRESSED");
        }

        HandleMovementInput();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovementInput()
    {
        _axisVector = new Vector2(_player.GetAxis(Axis.Horizontal), _player.GetAxis(Axis.Vertical));
    }

    private void HandleMovement()
    {
        transform.position += new Vector3(_axisVector.x, _axisVector.y) * _speed;
    }
}
