using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;

    [SerializeField] private float _damage;

    [SerializeField] private float _shootInterval;

    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetNearestFighter();
        if(_target != null)
        {
            LookAtTarget();
            ShootForward();
        }
    }

    private void TargetNearestFighter()
    {
        //set _target to the transform of the nearest fighter
    }

    private void LookAtTarget()
    {

    }

    private void ShootForward() //use relative forward
    {

    }
}
