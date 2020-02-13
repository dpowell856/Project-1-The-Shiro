using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float _force;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.right * Time.deltaTime * _force;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
