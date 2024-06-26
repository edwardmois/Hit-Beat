using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            // Handle target hit
            Destroy(other.gameObject);
            // Increase score, combo, etc.
            Debug.Log("Target hit!");
        }
    }
}
