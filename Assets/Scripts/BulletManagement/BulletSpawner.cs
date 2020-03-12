using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

    [SerializeField] Mesh _mesh;

    [SerializeField] Material _material;

    [SerializeField] Vector2 _maxBulletPosition;

    [SerializeField] int _maxBulletCount;

    [SerializeField] float _bulletInterval;

    [SerializeField] float _bulletSpeed;

    [SerializeField] float _damagePerBullet;

    private List<Matrix4x4> _transformMatrix = new List<Matrix4x4>();

    private float _time;

    private float _lengthFighterAndBullet = 1;

    private Fighter[] _fighters;

    void Start()
    {
        _fighters = Fighters.GetAliveFighters(); //temp
    }

    protected void SpawnBullet(Transform trans)
    {
        if(_transformMatrix.Count == _maxBulletCount)
        {
            DestroyBullet(_transformMatrix[0]);
        }

        Matrix4x4 matrix = new Matrix4x4();
        matrix.SetTRS(trans.position, Quaternion.Euler(Vector3.zero), Vector3.one);
        _transformMatrix.Add(matrix);
    }

    protected void DestroyBullet(Matrix4x4 transformMatrix)
    {
        _transformMatrix.Remove(transformMatrix);
    }

    private void Update()
    {
        Graphics.DrawMeshInstanced(_mesh, 0, _material, _transformMatrix);
    }

    void FixedUpdate()
    {
        HandleBulletGeneration();
    }

    protected void HandleBulletGeneration()
    {
        _time += Time.fixedDeltaTime;
        if (_time > _bulletInterval)
        {
            SpawnBullet(transform);
            _time = 0;
        }

        for (int i = 0; i < _transformMatrix.Count; i++)
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
                _transformMatrix[i] = MoveBullet(_transformMatrix[i]);
                Fighter fighter = CheckForCollision(_transformMatrix[i]);

                if (fighter != null)
                {
                    fighter.TakeDamage(_damagePerBullet);
                    print("FIghter: " + fighter.name + " got hit for " + _damagePerBullet + " of damage");
                    DestroyBullet(_transformMatrix[i]);
                    break;
                }
            }
        }
    }

    protected virtual Matrix4x4 MoveBullet(Matrix4x4 matrix)
    {
        return MoveMatrix(matrix, Vector3.left * _bulletSpeed);
    }

    protected Matrix4x4 MoveMatrix(Matrix4x4 matrix, Vector3 movement)
    {
        matrix.SetColumn(3, matrix.GetColumn(3) + (Vector4)movement);
        return matrix;
    }

    private Fighter CheckForCollision(Matrix4x4 matrix)
    {
        foreach(Fighter fighter in _fighters)
        {
            if (Vector2.Distance(matrix.GetColumn(3), fighter.transform.position) <= _lengthFighterAndBullet)
            {
                return fighter;
            }
        }
        return null;
    }
}