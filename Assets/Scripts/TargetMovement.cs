using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 initialDirection; // Direction in which the target should move
    public float destroyDistanceBehindPlayer = 5f; // Distance behind the player to destroy the target

    private Transform player;

    void Start()
    {
        // Calculate and store the initial direction based on the target's forward vector
        initialDirection = transform.forward;

        player = Camera.main.transform; // Ensure the main camera is part of the XR Rig and is tagged as MainCamera
    }

    void Update()
    {
        // Move the target in its initial direction
        transform.Translate(initialDirection * speed * Time.deltaTime, Space.World);

        // Check if the target has passed the player
        if (transform.position.z < player.position.z - destroyDistanceBehindPlayer)
        {
            Destroy(gameObject);
        }
    }
}
