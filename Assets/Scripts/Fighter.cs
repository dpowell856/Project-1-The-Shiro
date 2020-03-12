using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxStamina;
    [SerializeField] private float _stamina;
    [SerializeField] private float _staminaRegenRate;
    [SerializeField] private float _dashCost;

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
    internal int position;
    protected float _health = 100;

    void Start()
    {
        player = Players.GetPlayer(_tempPlayerID);
        PassiveAbillity();

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

        if (player.GetAction(Action.Interact))
        {
            UseAbillity();
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
        if (_dash && _stamina >= 1)
        {
            Dash();
            _dash = false;
            _stamina -= 1;
        }

        Vector2 lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        _rb.rotation = angle;
    }

    protected abstract void UseAbillity();

    protected virtual void PassiveAbillity() {}

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

    private void HandleDashInput()  
    {
        _dash = true;
    }

    private void Dash()
    {
        transform.position += new Vector3(_axisVector.x, _axisVector.y);
    }

    private void DashRegen()
    {
        if ((_stamina + (_maxStamina * _staminaRegenRate)) < _maxStamina)
        {
            _stamina += (_maxStamina * _staminaRegenRate);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, transform.rotation);
        //Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        //bulletRb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }
}
