using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowDirection : MonoBehaviour
{
    public Transform arrow; // Reference to the arrow child object

    public void SetDirection(Vector3 direction)
    {
        // Set the Z rotation of the arrow to indicate direction without altering Y rotation
        if (direction == Vector3.left)
        {
            arrow.localRotation = Quaternion.Euler(0, 0, -90); // Pointing left (hit from right)
        }
        else if (direction == Vector3.right)
        {
            arrow.localRotation = Quaternion.Euler(0, 0, 90); // Pointing right (hit from left)
        }
        else if (direction == Vector3.up)
        {
            arrow.localRotation = Quaternion.Euler(0, 0, 0); // Pointing up (hit from bottom)
        }
    }

    public Vector3 GetDirection()
    {
        // Return the direction based on the current rotation
        if (arrow.localRotation == Quaternion.Euler(0, 0, -90))
        {
            return Vector3.left;
        }
        else if (arrow.localRotation == Quaternion.Euler(0, 0, 90))
        {
            return Vector3.right;
        }
        else
        {
            return Vector3.up;
        }
    }
}