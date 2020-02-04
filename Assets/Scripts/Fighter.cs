using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private float _speed;

    public Player player { get; private set; }

    private Vector2 _axisVector;

    private bool _dash;

    void Start()
    {
        player = Players.GetPlayer(Player.ID.player0);
    }

    void Update()
    {
        // GetAction is a boolean that returns true when the button is down
        if (player.GetAction(Action.Shoot))
        {
            print("SHOOT BUTTON HAS BEEN PRESSED");
        }

        if (player.GetAction(Action.Dash))
        {
            print("PLAYER HAS DODGED");
            HandleDashInput();
        }

        HandleMovementInput();
    }

    void FixedUpdate()
    {
        HandleMovement();
        if (_dash)
        {
            Dash();
            _dash = false;
        }
    }

    private void HandleMovementInput()
    {
        _axisVector = new Vector2(player.GetAxis(Axis.Horizontal), player.GetAxis(Axis.Vertical));
    }

    private void HandleMovement()
    {
        transform.position += new Vector3(_axisVector.x, _axisVector.y) * _speed;
    }

    private void HandleDashInput()
    {
        _dash = true;
    }

    private void Dash()
    {
        transform.position += new Vector3(_axisVector.x, _axisVector.y);
    }
}
