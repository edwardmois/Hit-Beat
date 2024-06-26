using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Prefab of the target to spawn
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 1f; // Time in seconds between spawns
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnTarget();
            timer = 0;
        }
    }

    void SpawnTarget()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned!");
            return;
        }

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(targetPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        Debug.Log("Spawned a new target at " + spawnPoints[spawnIndex].position);
    }
}
