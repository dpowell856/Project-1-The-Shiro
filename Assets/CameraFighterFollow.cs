using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFighterFollow : MonoBehaviour
{
    [SerializeField] private float _borderSize;

    [SerializeField] private float _followTime;

    [SerializeField] private float _zoomTime;

    private List<Transform> _fighters = new List<Transform>();

    private Camera _camera;

    private Bounds _fighterBounds;

    private Vector3 _cameraMoveVelocity;
    private float _cameraZoomSpeed;

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    void Start()
    {
        StartCoroutine(FindAllPlayers());
    }

    private IEnumerator FindAllPlayers()
    {
        yield return new WaitForSeconds(0.3f);
        foreach (Fighter fighter in FindObjectsOfType<Fighter>())
        {
            _fighters.Add(fighter.transform);
        }
    }

    void LateUpdate()
    {
        if(_fighters.Count > 0)
        {
            CalculateFighterBounds();
            Move();
            if (_fighters.Count > 1)
            {
                Zoom();
            }
        }
    }

    private void Move()
    {
        Vector3 targetPosition = _fighterBounds.center;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _cameraMoveVelocity, _followTime);
    }

    private void Zoom()
    {
        _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, GetOrthographicSize() + _borderSize, ref _cameraZoomSpeed, _zoomTime);
    }
    
    private float GetOrthographicSize()
    {
        Vector2 greatestDistanceVector = _fighterBounds.size;
        float screenSizeBasedOnX = greatestDistanceVector.x / _camera.aspect;
        float screenSizeBasedOnY = greatestDistanceVector.y * _camera.aspect;

        if (screenSizeBasedOnX > screenSizeBasedOnY)
        {
            return (greatestDistanceVector.x / _camera.aspect) / 2;
        }
        else
        {
            return greatestDistanceVector.y / 2;
        }
    }

    private void CalculateFighterBounds()
    {
        Bounds bounds = new Bounds(_fighters[0].position, Vector3.zero);

        foreach(Transform trans in _fighters)
        {
            bounds.Encapsulate(trans.position);
        }

        _fighterBounds = bounds;
    }
}


