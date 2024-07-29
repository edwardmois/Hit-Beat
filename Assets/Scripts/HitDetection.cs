using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private GameManager gameManager;
    public float kickForce = 10f; // Force applied to the target on hit
    public float lifeTime = 5f; // Time before the target is destroyed if not hit
    public GameObject hitEffectPrefab; // Reference to the hit effect prefab

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        // Start the destruction countdown
        Destroy(gameObject, lifeTime);
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

            // Instantiate hit effect at the target's position
            if (hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                Debug.Log("Hit effect instantiated.");
            }
            else
            {
                Debug.LogError("Hit effect prefab is null.");
            }

            // Apply force to the target's Rigidbody (optional)
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 forceDirection = (transform.position - other.transform.position).normalized;
                rb.AddForce(forceDirection * kickForce, ForceMode.Impulse);
                Debug.Log("Force applied to target: " + forceDirection * kickForce);
            }

            // Destroy the target immediately
            Destroy(gameObject);
        }
    }
}
