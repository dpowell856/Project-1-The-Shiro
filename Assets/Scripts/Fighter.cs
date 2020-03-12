using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Player.ID _tempPlayerID;

    public Player player { get; private set; }

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletForce = 20f;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Camera _cam;


    private Vector2 _axisVector;
    private Vector2 _mousePos;


    private bool _dash;
    internal int _position;

    void Start()
    {
        player = Players.GetPlayer(_tempPlayerID);

    }

    void Update()
    {
        // GetAction is a boolean that returns true when the button is down
        if (player.GetAction(Action.Shoot))
        {
            Shoot();
        }

        if (player.GetAction(Action.Dash))
        {
            print("PLAYER HAS DODGED");
            HandleDashInput();
        }


        HandleMovementInput();
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    
    void FixedUpdate()
    {
        //faceMouse();
        HandleMovement();
        if (_dash)
        {
            Dash();
            _dash = false;
        }

        Vector2 lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        _rb.rotation = angle;
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

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, transform.rotation);
        //Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        //bulletRb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }
}
