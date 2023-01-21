using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 3, -6); // make the camera offset relative to players coordinates
    public float smoothSpeed = 0.125f; // larger number = smoother
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

    }
}
