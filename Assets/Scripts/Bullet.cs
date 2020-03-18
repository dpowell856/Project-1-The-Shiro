using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

     private float _speed = 30;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * _speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
