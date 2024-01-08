using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMovementL1Right: MonoBehaviour
{
    public float rotationSpeed = 150f; // adjust the speed of rotation
    public float moveDistance = 3f; // adjust the distance it moves
    public float moveSpeed = 3.52f; // adjust the speed
    public float isRight = 1f;

    private float initialPosition;

    void Start()
    {
        initialPosition = transform.position.x; // store the initial x position
    }

    void Update()
    {
        // spin the object around its up axis (Y-axis in most cases)
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        // calculate the new x position using Mathf.Sin
        float newPosition = initialPosition + isRight * Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // update the object's position
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}

