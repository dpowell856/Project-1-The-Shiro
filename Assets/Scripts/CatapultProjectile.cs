using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultProjectile : Damageable
{
    // Start is called before the first frame update
    void Start() {
        
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

            print("Wall has been hit!");
            //Wall._life -=100;
            Die();
        }
        if (collision.CompareTag("Arrow")) {
            
            print("A player projectile has just hit the catapult projectile");
            TakeDamage();
        }
    }
}
