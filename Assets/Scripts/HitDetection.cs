using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private GameManager gameManager;
    public float kickForce = 10f; // Force applied to the target on hit
    private ArrowDirection arrowDirection;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        arrowDirection = GetComponent<ArrowDirection>();
        if (arrowDirection == null)
        {
            Debug.LogError("ArrowDirection component not found on target.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name + " at position: " + transform.position);

        if (other.gameObject.CompareTag("PlayerHand"))
        {
            Debug.Log("Trigger hit by PlayerHand!");

            Vector3 hitDirection = (other.transform.position - transform.position).normalized;

            // Log hit and arrow direction for debugging
            Debug.Log("Hit direction: " + hitDirection);
            Debug.Log("Expected direction: " + arrowDirection.GetDirection());

            // Allow for a wider range of acceptable hit directions
            Vector3 expectedDirection = arrowDirection.GetDirection();
            if (Vector3.Dot(hitDirection, expectedDirection) > 0.5f) // Adjust threshold as needed
            {
                Debug.Log("Hit direction correct!");

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
            else
            {
                Debug.Log("Hit direction incorrect. No score awarded.");
            }
        }
    }
}
