using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes; // Array of cube prefabs
    public Transform[] spawnPoints; // Array of spawn points
    public float beat = (60 / 120f); // Time interval between spawns
    private float timer; // Timer to track the time

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > beat)
        {
            // Instantiate a random cube at a random spawn point
            GameObject cube = Instantiate(cubes[Random.Range(0, cubes.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(Vector3.forward, Random.Range(0, 360));

            // Reset the timer
            timer = 0f;
        }
    }
}
