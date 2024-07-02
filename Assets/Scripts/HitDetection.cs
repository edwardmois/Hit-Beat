using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private GameManager gameManager;
    public float kickForce = 10f; // Force applied to the target on hit

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name + " at position: " + transform.position);

        if (other.gameObject.CompareTag("PlayerHand"))
        {
            Debug.Log("Trigger hit by PlayerHand!");

            if (gameManager != null)
            {
                gameManager.AddScore(10);
            }
            else
            {
                Debug.LogError("GameManager is null. Cannot add score.");
            }

            // Apply force to the target's Rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 forceDirection = (transform.position - other.transform.position).normalized;
                rb.AddForce(forceDirection * kickForce, ForceMode.Impulse);
                Debug.Log("Force applied to target: " + forceDirection * kickForce);
            }

            // Optionally destroy the target after a delay
            Destroy(gameObject, 2f); // Destroy after 2 seconds to allow the kick effect to be visible
        }
    }
}
