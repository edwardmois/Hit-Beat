using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public TargetSpawner targetSpawner;
    public AudioSource musicPlayer;
    public float beatInterval = 1f; // Adjust based on BPM

    void Start()
    {
        Debug.Log("BeatSpawner started");
        StartCoroutine(SpawnOnBeat());
    }

    IEnumerator SpawnOnBeat()
    {
        while (true)
        {
            Debug.Log("Spawning target on beat");
            targetSpawner.SpawnTarget(); // Trigger single spawn
            yield return new WaitForSeconds(beatInterval);
        }
    }
}
