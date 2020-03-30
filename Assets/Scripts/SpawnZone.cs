using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnZone : MonoBehaviour
{
    [System.Serializable] public struct SpawnInfo {
        public EnemyFactory enemyFactory;
        public float spawnFrequency;
        public float spawnFrequencyRandomnesRange;
    }

    public SpawnInfo[] spawnInfos;

    private Dictionary<GameObject, float> _objectSpawnTimeLinks = new Dictionary<GameObject, float>();

    private bool _spawnzoneActive = false;

    private Vector2 maxCorner, minCorner;

    private void Awake()
    {
        Rect spawnRect = GetComponent<RectTransform>().rect;
        maxCorner = (Vector2)transform.position + spawnRect.size / 2;
        minCorner = (Vector2)transform.position - spawnRect.size / 2;
    }

    private void Update()
    {
        if (_spawnzoneActive)
        {
            foreach (SpawnInfo spawnInfo in spawnInfos)
            {
                if (_objectSpawnTimeLinks.ContainsKey(spawnInfo.enemyFactory.GetGameObject()))
                {
                    if(Time.time >= _objectSpawnTimeLinks[spawnInfo.enemyFactory.GetGameObject()])
                    {
                        SpawnEnemy(spawnInfo.enemyFactory);
                        _objectSpawnTimeLinks[spawnInfo.enemyFactory.GetGameObject()] = CalculateSpawnTime(spawnInfo.spawnFrequency, spawnInfo.spawnFrequencyRandomnesRange);
                    }
                }
                else
                {
                    _objectSpawnTimeLinks.Add(spawnInfo.enemyFactory.GetGameObject(), CalculateSpawnTime(spawnInfo.spawnFrequency, spawnInfo.spawnFrequencyRandomnesRange));
                }
            }
        }
    }

    private void SpawnEnemy(EnemyFactory enemyFactory)
    {
        Vector3 positionToSpawn = new Vector2(Random.Range(minCorner.x, maxCorner.x), Random.Range(minCorner.y, maxCorner.y));
        enemyFactory.Spawn(positionToSpawn);
        
    }

    private float CalculateSpawnTime(float frequency, float randomnesRange)
    {
        return (frequency + Random.Range(-randomnesRange, randomnesRange)) + Time.time;
    }

    public void SetSpawnzoneActive(bool active)
    {
        _spawnzoneActive = active;
    }

    public bool GetSpawnzoneActive()
    {
        return _spawnzoneActive;
    }
}
