using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovementL3Down: MonoBehaviour
{
    public float rotationSpeed = 150f; // adjust the speed of rotation
    public float moveDistance = 3.2f; // adjust the distance it moves
    public float moveSpeed = 3.6f; // adjust the speed

    private float initialPosition;

    void Start()
    {
        initialPosition = transform.position.y; // store the initial y position
    }

    void Update()
    {
        // spin the object around its up axis (Y-axis in most cases)
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        // calculate the new y position using Mathf.Sin
        float newPosition = initialPosition - Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // update the object's position
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
}

