using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyFighter
{
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    void fixedUpdate()
    {
        move();
        shoot();
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
