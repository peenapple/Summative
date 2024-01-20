using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiagonalSawMovement : MonoBehaviour
{
    public float rotationSpeed = 150f; // adjust the speed of rotation
    public float moveDistance = 3.2f; // adjust the distance it moves
    public float moveSpeed = 3.6f; // adjust the speed
    public bool isRight = true;
    public float rest = 0f;

    private float initialY;
    private float initialX;
    private bool active = false;

    void Start()
    {
        StartCoroutine(Rest(rest));
    }

    IEnumerator Rest(float duration)
    {
        yield return new WaitForSeconds(duration);
        active = true;
        initialY = transform.position.y; // store the initial y position
        initialX = transform.position.x; // store the initial x position
    }

    void Update()
    {
        if (active)
        {
            // spin the object around its up axis (Y-axis in most cases)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            if (isRight)
            {
                // calculate the new y position using Mathf.Sin
                float newPositionY = initialY + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

                // calculate the new x position using Mathf.Sin
                float newPositionX = initialX + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

                // update the object's position
                transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);
            }
            else
            {
                // calculate the new y position using Mathf.Sin
                float newPositionY = initialY - Mathf.Sin(Time.time * moveSpeed) * moveDistance;

                // calculate the new x position using Mathf.Sin
                float newPositionX = initialX + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

                // update the object's position
                transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);
            }
        }
    }

}
