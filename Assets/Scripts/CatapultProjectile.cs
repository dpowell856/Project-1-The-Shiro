using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultProjectile : Damageable
{
    [SerializeField] protected Vector3 _velocity;

    [SerializeField] private float _damage;

    // Start is called before the first frame update
    void Start() {
        
        _health = _totalHealth;
    }

    // Fixed update is called once per fixed interval
    void FixedUpdate() {

        float dt = Time.fixedDeltaTime;
        transform.position += _velocity * dt;

        if(_health <= 0) {
              Die();
		}
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if (collision.CompareTag("Wall")) {
            collision.GetComponent<Wall>().TakeDamage(_damage);
            print("Wall has been hit!");
            Die();
        }
        //if (collision.CompareTag("Bullet")) {
            
        //    print("A player projectile has just hit the catapult projectile");
        //    TakeDamage(10);
        //}
    }
}
