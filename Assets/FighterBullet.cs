using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterBullet : Bullet {
    protected override void DealDamage(Collider2D collider, float amount)
    {
        collider.GetComponent<Damageable>().TakeDamage(amount);
    }

    protected override bool IsHitDamaging(Collider2D collider)
    {
        return collider.GetComponent<Damageable>();
    }

    protected override bool IsHitSolid(Collider2D collider)
    {
        return false; // temp
    }
}
