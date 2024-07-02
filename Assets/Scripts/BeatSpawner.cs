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
        StartCoroutine(SpawnOnBeat());
    }

    IEnumerator SpawnOnBeat()
    {
        while (true)
        {
            StartCoroutine(targetSpawner.SpawnTargets());
            yield return new WaitForSeconds(beatInterval);
        }
    }
}
