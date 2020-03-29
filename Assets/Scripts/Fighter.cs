using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{

    private float _speed;
    private float _maxStamina;
    private float _staminaRegenRate;
    private float _maxHealth;

    public Player player { get; private set; }

    [SerializeField] private GameObject _bulletPrefab;

    private Transform _firePoint;

    private Camera _mainCamera;

    private Vector2 _axisVector;
    private Vector2 _lookAxisVector;
    private Vector2 _mousePos;

    private bool _dash;
    protected float _health;
    protected float _stamina;

    private bool _useMouse;

    private void Awake()
    {
        _firePoint = transform.GetChild(1); //trash but will work
    }

    protected virtual void Start()
    {
        _mainCamera = FindObjectOfType<Camera>(); //change if multiple cameras
        InvokeRepeating("DashRegen", 1.0f, 1.0f);
    }

    public void Instatiate(Player.ID playerID, float speed, float maxHealth, float maxStamina, float staminaRegenRate, bool useMouse = false)
    {
        player = Players.GetPlayer(playerID);
        _speed = speed;
        _maxHealth = maxHealth;
        _maxStamina = maxStamina;
        _staminaRegenRate = staminaRegenRate;
        _useMouse = useMouse;

        _health = _maxHealth;
        _stamina = _maxStamina;
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
            HandleDashInput();
        }

        HandleMovementInput();
        HandleLookInput();
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void HandleRotation()
    {
        if(_lookAxisVector != Vector2.zero)
        {
            transform.up = _lookAxisVector;
        }
        if (_useMouse)
        {
            transform.up = _mousePos - (Vector2)transform.position;
        }
    }

    protected abstract void UseAbillity();

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
        print("player: " + this.name + ", has died");
        Destroy(gameObject);
    }

    private void HandleLookInput()
    {
        _lookAxisVector = new Vector2(player.GetAxis(Axis.LookHorizontal), player.GetAxis(Axis.LookVertical));
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

        if ((_stamina + _staminaRegenRate) < _maxStamina)

        {
            _stamina += _staminaRegenRate;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, transform.rotation);
    }
}
