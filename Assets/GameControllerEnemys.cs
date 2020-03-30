using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerEnemys : MonoBehaviour
{
    [System.Serializable] private struct SpawnZoneTiming {
        public float time;
        public float endtime;
        public SpawnZone spawnZone;
    }

    [SerializeField] private GameObject _bulletsspawners;

    [SerializeField] private SpawnZoneTiming[] _spawnZoneTimings;

    private float _startTime;

    private Fireplaces _fireplaces;

    private DangerBar _dangerBar;

    private bool _keepCheking = true;

    private void Start()
    {
        _dangerBar = FindObjectOfType<DangerBar>();
        _dangerBar.gameObject.SetActive(false);
        _fireplaces = GameObject.FindObjectOfType<Fireplaces>();
    }

    private void Update()
    {
        if (_keepCheking)
        {
            if (_fireplaces.IsAllActiveFireplacesLit())
            {
                Destroy(_fireplaces.gameObject);
                StartCoroutine(Play());
                _keepCheking = false;
            }
        }
    }

    private IEnumerator Play()
    {
        Destroy(FindObjectOfType<GameControllerBullets>());
        Destroy(_bulletsspawners);
        _dangerBar.gameObject.SetActive(true);
        _startTime = Time.time;
        while (true)
        {
            foreach (SpawnZoneTiming timing in _spawnZoneTimings)
            {
                if (!timing.spawnZone.GetSpawnzoneActive())
                {
                    if (_startTime + timing.time <= Time.time && _startTime + timing.endtime >= Time.time)
                    {
                        timing.spawnZone.SetSpawnzoneActive(true);
                    }
                }
                else if ( _startTime + timing.endtime <= Time.time)
                {
                    timing.spawnZone.SetSpawnzoneActive(false);
                }
            }
            yield return null;
        }
    }

    public float OverallEndTime()
    {
        float longest = 0;
        foreach (SpawnZoneTiming timing in _spawnZoneTimings)
        {
            if(timing.endtime > longest)
            {
                longest = timing.endtime;
            }
        }
        return _startTime + longest;
    }
}
