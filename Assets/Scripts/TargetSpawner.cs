using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnPoints;

    public void SpawnTarget()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Debug.Log("Spawning target at: " + spawnPoint.position);
        Instantiate(targetPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}