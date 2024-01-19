using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalSawMovement : MonoBehaviour
{
    public float rotationSpeed = 150f; // adjust the speed of rotation
    public float moveDistance = 3.2f; // adjust the distance it moves
    public float moveSpeed = 3.6f; // adjust the speed
    public bool isUp = true;

    private float initialY;
    private float initialX;

    void Start()
    {
        initialY = transform.position.y; // store the initial y position
        initialX = transform.position.x; // store the initial x position
    }

    void Update()
    {
        // spin the object around its up axis (Y-axis in most cases)
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        // calculate the new y position using Mathf.Sin
        float newPositionY = initialY + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // calculate the new x position using Mathf.Sin
        float newPositionX = initialX + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // update the object's position
        transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);
    }

}
