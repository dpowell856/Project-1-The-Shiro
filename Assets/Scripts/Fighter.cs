using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float bulletForce = 20f;

    [SerializeField] private Player.ID _tempPlayerID;

    public Player player { get; private set; }
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private Vector2 _axisVector;


    private bool _dash;
    internal int position;

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
    }

    
    void FixedUpdate()
    {
        faceMouse();
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

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
