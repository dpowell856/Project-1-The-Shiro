using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float _speed = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(Vector2. * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
