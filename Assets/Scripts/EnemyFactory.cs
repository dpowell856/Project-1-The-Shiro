using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private float _speed, _speedRandomiserPercentage, _rangeFromEnemys, _rangeFromEnemysRandomiserPercentage, _rangeFromPlayer;

    [SerializeField] protected GameObject _enemyObject;

    public virtual void Spawn(Vector3 position)
    {
        GameObject enemy = Instantiate(_enemyObject, position, Quaternion.identity, null);

        float randomSpeed = Randomiser(_speed, _speedRandomiserPercentage);
        float randomRangeFromEnemys = Randomiser(_rangeFromEnemys, _rangeFromEnemysRandomiserPercentage);

        enemy.GetComponent<EnemyFighter>().Instantiate(randomSpeed, randomRangeFromEnemys, _rangeFromPlayer);
    }

    private float  Randomiser(float number, float randomness)
    {
        return number * Random.Range(1 - _speedRandomiserPercentage, 1 + _speedRandomiserPercentage);
    }

    public virtual GameObject GetGameObject()
    {
        return _enemyObject;
    }
}
