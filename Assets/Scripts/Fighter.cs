using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Player.ID _tempPlayerID;

    public Player player { get; private set; }
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private Vector2 _axisVector;

    private bool _dash;
    internal int position;
    protected float _health = 100;

    protected virtual void Start()
    {
        player = Players.GetPlayer(_tempPlayerID);
    }

    protected virtual void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (player.GetAction(Action.Shoot))
        {
            Shoot();
        }

        //if (player.GetAction(Action.))
        //{
            //UseAbillity();
        //}

        if (player.GetAction(Action.Dash))
        {
            HandleNarutoInput();
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

    protected abstract void UseAbillity();

    public void TakeDamage(float damage)
    {
        _health -= damage;
        checkForDeath();
    }

    private void checkForDeath()
    {
        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void HandleMovementInput()
    {
        _axisVector = new Vector2(player.GetAxis(Axis.Horizontal), player.GetAxis(Axis.Vertical));
    }

    private void HandleMovement()
    {
        transform.position += new Vector3(_axisVector.x, _axisVector.y) * _speed;
    }

    private void HandleNarutoInput()
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
    }
}
