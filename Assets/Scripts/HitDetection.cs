using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private GameManager gameManager;

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
                gameManager.AddScore(10); // Add points on hit
            }
            else
            {
                Debug.LogError("GameManager is null. Cannot add score.");
            }

            Destroy(gameObject); // Destroy target on hit
        }
    }
}
