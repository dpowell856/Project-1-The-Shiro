using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateMovement : MonoBehaviour
{
    [SerializeField] private float _timeBetweenCoordinates;

    [SerializeField] private Vector3[] _coordinates;

    private Vector3 _previousTarget;

    private Vector3 _target;

    void Start()
    {
         _target = _coordinates[0];
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(_previousTarget, _target, _timeBetweenCoordinates);
    }
}
