using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class CollectableSpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 spawnCenter;
    public float spawnRadius = 10f;
    public float spawnInterval = 2f;
    private int maxAttempts = 10;

    private float timer;

    void Start()
    {
        timer = spawnInterval;

        Vector3 spawnPoint;
        if (FindRandomNavMeshPoint(spawnCenter, spawnRadius, out spawnPoint))
        {
            Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);
            Debug.Log("Object spawned");
        }
        else
        {
            Debug.Log("Object unable to spawn");
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = spawnInterval;

            Vector3 spawnPoint;
            if (FindRandomNavMeshPoint(spawnCenter, spawnRadius, out spawnPoint))
            {
                Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);
                Debug.Log("Object spawned");
            }
            else
            {
                Debug.Log("Object unable to spawn");
            }
        }
    }

    bool FindRandomNavMeshPoint(Vector3 center, float radius, out Vector3 result)
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * radius;
            randomPoint.y = center.y + 1.5f; 

            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
    }
}
