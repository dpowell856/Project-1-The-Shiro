using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

    [SerializeField] Mesh _mesh;

    [SerializeField] Material _material;

    //[SerializeField] GameObject _bullet;

    [SerializeField] Vector2 _maxBulletPosition;

    [SerializeField] int _maxBulletCount;

    private GameObject[] _bullets;

    //private int _bulletsIndex = 0;

    private List<Matrix4x4> _transformMatrix = new List<Matrix4x4>();

    private float _time;

    protected void SpawnBullet(Transform trans)
    {
        if(_transformMatrix.Count == _maxBulletCount)
        {
            DestroyBullet(_transformMatrix[0]);
        }
        _transformMatrix.Add(Matrix4x4.TRS(trans.position, trans.rotation, trans.localScale));
    }

    protected void DestroyBullet(Matrix4x4 transformMatrix)
    {
        print("Destroyed");
        _transformMatrix.Remove(transformMatrix);
    }

    void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
        if(_time > 0.5f)
        {
            SpawnBullet(transform);
            _time = 0;
            print("SpawnBullet");
        }

        for(int i = 0; i < _transformMatrix.Count; i++)
        {
            if (_transformMatrix[i].m03 < _maxBulletPosition.x)
            {
                DestroyBullet(_transformMatrix[i]);
            }
            else if (_transformMatrix[i].m13 == _maxBulletPosition.y)
            {
                DestroyBullet(_transformMatrix[i]);
            }
            else
            {
                print("Before: " + _transformMatrix[i].GetColumn(3));
                _transformMatrix[i].SetColumn(3, _transformMatrix[i].GetColumn(3) + (Vector4)Vector3.left);
                //MoveMatrix(matrix, Vector3.left);
                print("After: " + _transformMatrix[i].GetColumn(3));
            }
        }

        /*
        foreach (Matrix4x4 matrix in _transformMatrix)
        {
            if (matrix.m03 < _maxBulletPosition.x)
            {
                DestroyBullet(matrix);
            }
            else if (matrix.m13 == _maxBulletPosition.y)
            {
                DestroyBullet(matrix);
            }
            else
            {
                print("Before: " + matrix.GetColumn(3));
                Vector4 movementVector4 = (Vector4)Vector3.left;
                movementVector4.w = 1;
                matrix.SetColumn(3, matrix.GetColumn(3) + movementVector4);
                //MoveMatrix(matrix, Vector3.left);
                print("After: " + matrix.GetColumn(3));
            }
        }
        */

        Graphics.DrawMeshInstanced(_mesh, 0, _material, _transformMatrix);
    }

    protected virtual void MoveMatrix(Matrix4x4 matrix, Vector3 movement)
    {
        Vector4 movementVector4 = (Vector4)movement;
        movementVector4.w = 1;
        matrix.SetColumn(3, matrix.GetColumn(3) + movementVector4);
    }

    /*void Start()
    {
        _bullets = new GameObject[_maxBulletCount];
        for(int i = 0; i < _maxBulletCount; i++)
        {
            _bullets[i] = Instantiate(_bullet);
            _bullets[i].SetActive(false);
        }
    }*/
}