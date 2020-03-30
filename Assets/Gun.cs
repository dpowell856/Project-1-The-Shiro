using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;

    private Transform _firePoint;

    private void Awake()
    {
        foreach(Transform trans in GetComponentsInChildren<Transform>())
        {
            if (trans.CompareTag("FirePoint"))
            {
                _firePoint = trans;
            }
        }
    }

    public void Shoot()
    {
        Instantiate(_bullet, _firePoint.position, transform.rotation, null);
    }
}
