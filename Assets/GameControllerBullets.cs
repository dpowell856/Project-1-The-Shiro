using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerBullets : MonoBehaviour
{
    [System.Serializable] private struct BulletSpawnerTiming {
        public float time;
        public float endtime;
        public ProjectileSpawner bulletSpawner;
    }

    [SerializeField] private BulletSpawnerTiming[] _bulletSpawnerTimings;

    private float _startTime;

    public void Start()
    {
        _startTime = Time.time;
    }

    public void Update()
    {
        foreach(BulletSpawnerTiming timing in _bulletSpawnerTimings)
        {
            if (!timing.bulletSpawner.IsActive())
            {
                if(_startTime + timing.time <= Time.time && _startTime + timing.endtime >= Time.time)
                {
                    timing.bulletSpawner.SetActive(true);
                }
            }
            else if(_startTime + timing.endtime <= Time.time)
            {
                timing.bulletSpawner.SetActive(false);
            }
        }
    }

    public float OverallEndTime()
    {
        float longest = 0;
        foreach (BulletSpawnerTiming timing in _bulletSpawnerTimings)
        {
            if(timing.endtime > longest)
            {
                longest = timing.endtime;
            }
        }
        return _startTime + longest;
    }
}
