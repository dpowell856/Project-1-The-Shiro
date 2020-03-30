using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet {
    protected override void DealDamage(Collider2D collider, float amount)
    {
        collider.GetComponent<Fighter>().TakeDamage(amount);
    }

    protected override bool IsHitDamaging(Collider2D collider)
    {
        return collider.CompareTag("Player");
    }

    protected override bool IsHitSolid(Collider2D collider)
    {
        return false; // temp
    }
}
