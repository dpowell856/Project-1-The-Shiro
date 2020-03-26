using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] public struct SpawnInfo {
        public GameObject objectToSpawn;
        public float spawnFrequency;
        public float spawnFrequencyRandomnessSkew;
    }

    public SpawnInfo[] spawnInfos;

    private Dictionary<GameObject, float> _objectSpawnTimeLinks;

    private bool _spawnzoneActive;

    private Vector2 topRightCornerCoordinates;
    private Vector2 bottomLeftCoordinates;

    private void Start()
    {
        Vector2 size = transform.localScale;
        topRightCornerCoordinates = new Vector2(transform.position.x + size.x / 2, transform.position.y + size.y / 2);
        bottomLeftCoordinates = topRightCornerCoordinates - size;
    }

    private void Update()
    {
        if (_spawnzoneActive)
        {
            foreach (SpawnInfo spawnInfo in spawnInfos)
            {
                if (_objectSpawnTimeLinks.ContainsKey(spawnInfo.objectToSpawn))
                {
                    _objectSpawnTimeLinks[spawnInfo.objectToSpawn] += Time.fixedDeltaTime;
                    if(_objectSpawnTimeLinks[spawnInfo.objectToSpawn] >= Time.time)
                    {
                        SpawnObject(spawnInfo.objectToSpawn);
                        _objectSpawnTimeLinks[spawnInfo.objectToSpawn] = CalculateSpawnTime(spawnInfo.spawnFrequency, spawnInfo.spawnFrequencyRandomnessSkew);
                    }
                }
                else
                {
                    _objectSpawnTimeLinks.Add(spawnInfo.objectToSpawn, CalculateSpawnTime(spawnInfo.spawnFrequency, spawnInfo.spawnFrequencyRandomnessSkew));
                }
            }
        }
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        Vector3 positionToSpawn = new Vector2(Random.Range(bottomLeftCoordinates.x, topRightCornerCoordinates.x), Random.Range(bottomLeftCoordinates.y, topRightCornerCoordinates.y));
        //Instantiate(objectToSpawn, positionToSpawn);
    }

    private float CalculateSpawnTime(float frequency, float randomnessSkew)
    {
        return (frequency * Random.Range(0.8f + randomnessSkew, 1.2f + randomnessSkew)) + Time.time;
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
