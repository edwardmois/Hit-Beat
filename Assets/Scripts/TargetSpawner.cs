using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] holePositions; // Array of hole positions

    public void SpawnTarget()
    {
        // Select a random hole position
        Transform holePosition = holePositions[Random.Range(0, holePositions.Length)];
        // Instantiate the target at the selected hole position
        Instantiate(targetPrefab, holePosition.position, holePosition.rotation);
    }
}
