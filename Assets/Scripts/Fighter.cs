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
    [SerializeField] private float _maxHealth;

    [SerializeField] private Player.ID _tempPlayerID;

    public Player player { get; private set; }

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletForce = 20f;

    private Camera _mainCamera;

    private Vector2 _axisVector;
    private Vector2 _mousePos;

    private bool _dash;
    internal int position;
    protected float _health;

    void Start()
    {
        _health = _maxHealth;
        player = Players.GetPlayer(_tempPlayerID);
        _mainCamera = FindObjectOfType<Camera>(); //change if multiple cameras
        PassiveAbillity();

    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
        if (_dash && _stamina >= 1)
        {
            Dash();
            _dash = false;
            _stamina -= 1;
        }
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
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void HandleRotation()
    {
        transform.LookAt(_mousePos);
    }

    protected abstract void UseAbillity();

    protected virtual void PassiveAbillity() {}

    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        _health += amount;
        if(_health > _maxHealth)
        {
            _health = _maxHealth;
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
    }
}
