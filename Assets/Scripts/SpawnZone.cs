using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnZone : MonoBehaviour
{
    [System.Serializable] public struct SpawnInfo {
        public GameObject objectToSpawn;
        public float spawnFrequency;
        public float spawnFrequencyRandomnesRange;
    }

    public SpawnInfo[] spawnInfos;

    private Dictionary<GameObject, float> _objectSpawnTimeLinks = new Dictionary<GameObject, float>();

    private bool _spawnzoneActive = true;

    private Vector2 maxCorner, minCorner;

    private void Awake()
    {
        Rect spawnRect = GetComponent<RectTransform>().rect;
        print("SpawnREctCenter: " + transform.position);
        print("SpawnRectangleSize: " + spawnRect.size);
        maxCorner = (Vector2)transform.position + spawnRect.size / 2;
        print("Max corner: " + maxCorner);
        minCorner = (Vector2)transform.position - spawnRect.size / 2;
        print("Min corner: " + minCorner);
    }

    private void Update()
    {
        if (_spawnzoneActive)
        {
            foreach (SpawnInfo spawnInfo in spawnInfos)
            {
                if (_objectSpawnTimeLinks.ContainsKey(spawnInfo.objectToSpawn))
                {
                    if(Time.time >= _objectSpawnTimeLinks[spawnInfo.objectToSpawn])
                    {
                        SpawnObject(spawnInfo.objectToSpawn);
                        _objectSpawnTimeLinks[spawnInfo.objectToSpawn] = CalculateSpawnTime(spawnInfo.spawnFrequency, spawnInfo.spawnFrequencyRandomnesRange);
                    }
                }
                else
                {
                    _objectSpawnTimeLinks.Add(spawnInfo.objectToSpawn, CalculateSpawnTime(spawnInfo.spawnFrequency, spawnInfo.spawnFrequencyRandomnesRange));
                }
            }
        }
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        Vector3 positionToSpawn = new Vector2(Random.Range(minCorner.x, maxCorner.x), Random.Range(minCorner.y, maxCorner.y));
        print("Position to spawn: " + positionToSpawn);
        Instantiate(objectToSpawn, positionToSpawn, Quaternion.identity, null);
    }

    private float CalculateSpawnTime(float frequency, float randomnesRange)
    {
        return (frequency + Random.Range(-randomnesRange, randomnesRange)) + Time.time;
    }

    private void SetSpawnzoneActive(bool active)
    {
        _spawnzoneActive = active;
    }

    private bool GetSpawnzoneActive()
    {
        return _spawnzoneActive;
    }
}
