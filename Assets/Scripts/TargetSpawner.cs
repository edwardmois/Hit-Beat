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
        GameObject target = Instantiate(targetPrefab, spawnPoint.position, spawnPoint.rotation);

        // Set random direction for arrow (left, right, up)
        Vector3[] directions = { Vector3.left, Vector3.right, Vector3.up };
        Vector3 selectedDirection = directions[Random.Range(0, directions.Length)];

        ArrowDirection arrowDirection = target.GetComponent<ArrowDirection>();
        if (arrowDirection != null)
        {
            arrowDirection.SetDirection(selectedDirection);
        }
    }
}
