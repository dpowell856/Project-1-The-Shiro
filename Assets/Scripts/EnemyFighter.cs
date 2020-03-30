using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Damageable {

    protected float _speed, _rangeFromEnemys, _rangeFromPlayer;

    protected Transform _closestsEnemyFighter { get; private set; }
    protected Transform _closetsFighter { get; private set; }

    public virtual void Instantiate(float speed, float rangeFromEnemys, float  rangeFromPlayer)
    {
        _speed = speed;
        _rangeFromEnemys = rangeFromEnemys;
        _rangeFromPlayer = rangeFromPlayer;
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(FindTargets());
    }

    protected virtual void FixedUpdate()
    {
        move();
    }

    private IEnumerator FindTargets()
    {
        while (true)
        {
            _closetsFighter = FindClosest<Fighter>();
            Transform trans = FindClosest<EnemyFighter>();
            if (trans != _closestsEnemyFighter)
            {
                _closestsEnemyFighter = FindClosest<EnemyFighter>();
                yield return 60;
            }
            yield return 10;
        }
    }

    protected void move()
    {
        Vector2 directionToMove = Vector2.zero;

        transform.up = _closetsFighter.position - transform.position;
        if(_rangeFromPlayer <= Vector2.Distance(_closetsFighter.position, transform.position))
        {
            directionToMove = transform.up;
        }

        if (_closestsEnemyFighter)
        {
            Vector3 enemyPositionRelativeToThis = _closestsEnemyFighter.position - transform.position;
            if (_rangeFromEnemys >= enemyPositionRelativeToThis.sqrMagnitude)
            {
                directionToMove += -(Vector2)enemyPositionRelativeToThis.normalized;
                directionToMove.Normalize();
            }
        }

        transform.position += (Vector3)directionToMove * _speed;
    }

    private Vector2 FindClosetsPosition<T>() where T : MonoBehaviour
    {
        return (Vector2)FindClosest<T>().position - (Vector2)transform.position;
    }

    private Transform FindClosest<T>() where T: MonoBehaviour
    {
        float distanceToClosestT = Mathf.Infinity;
        T closestT = null;
        T[] allT = GameObject.FindObjectsOfType<T>();

        foreach (T t in allT)
        {
            float distanceToT = (t.transform.position - transform.position).sqrMagnitude;
            if(distanceToT == 0) // for performance
            {
                if (GetComponent<T>())
                {
                    if(t == GetComponent<T>())
                    {
                        continue;
                    }
                }
            }
            if (distanceToT < distanceToClosestT)
            {
                distanceToClosestT = distanceToT;
                closestT = t;
            }
        }
        return closestT.transform;
    }
}
