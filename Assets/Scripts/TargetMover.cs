using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the target moves towards the player
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Find the player in the scene (assuming the player has a "Player" tag)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the target towards the player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
    }
}
