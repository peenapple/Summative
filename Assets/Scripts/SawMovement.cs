using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float rotationSpeed = 150f; // adjust the speed of rotation
    public float moveDistance = 2.2f; // adjust the distance it moves left and right
    public float moveSpeed = 3.5f; // adjust the speed of left-right movement

    private float initialPosition;

    void Start()
    {
        initialPosition = transform.position.x; // store the initial x position
    }

    void Update()
    {
        // spin the object around its up axis (Y-axis in most cases)
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        // calculate the new x position for left-right movement using Mathf.Sin
        float newPosition = initialPosition + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // update the object's position
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}

