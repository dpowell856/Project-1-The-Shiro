using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed, _damage;


    public void Instantiate(float speed, float damage)
    {
        _speed = speed;
        _damage = damage;
        StartCoroutine(KillTimer(10));
    }

    private IEnumerator KillTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Fighter>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position += transform.right * _speed;
    }
}