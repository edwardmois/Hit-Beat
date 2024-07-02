using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;

    void Start()
    {
        player = Camera.main.transform; // Ensure the main camera is part of the XR Rig and is tagged as MainCamera
    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
