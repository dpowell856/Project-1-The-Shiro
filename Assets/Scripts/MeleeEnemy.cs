using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyFighter
{

    void FixedUpdate()
    {
        move();
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {
            print("Player has been hit by a melee enemy");
        }
    }
}
