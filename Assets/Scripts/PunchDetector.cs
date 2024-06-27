using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDetector : MonoBehaviour
{
    public float minPunchSpeed = 1.0f; // Minimum speed to register a punch
    public GameObject punchEffect; // Reference to the visual effect prefab
    private Vector3 previousPosition;
    private Vector3 currentPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        currentPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            float speed = (currentPosition - previousPosition).magnitude / Time.deltaTime;

            if (speed >= minPunchSpeed)
            {
                Destroy(other.gameObject);
                Debug.Log("Target hit and destroyed!");

                // Instantiate visual effect at the point of collision
                Instantiate(punchEffect, other.transform.position, Quaternion.identity);
            }
        }

        previousPosition = currentPosition;
    }
}
