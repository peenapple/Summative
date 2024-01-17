using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSawMovement: MonoBehaviour
{
    public float rotationSpeed = 150f; // adjust the speed of rotation
    public float moveDistance = 3.2f; // adjust the distance it moves
    public float moveSpeed = 3.6f; // adjust the speed
    public SpriteRenderer spriteRenderer;
    public bool isUp = true;

    private float initialPosition;
    private bool isActivated = true;

    void Start()
    {
        initialPosition = transform.position.y; // store the initial y position
        isActivated = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isActivated)
        {
            // spin the object around its up axis (Y-axis in most cases)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            if (isUp )
            {
                // calculate the new y position using Mathf.Sin
                float newPosition = initialPosition + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

                // update the object's position
                transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
            }
            else
            {
                // calculate the new y position using Mathf.Sin
                float newPosition = initialPosition - Mathf.Sin(Time.time * moveSpeed) * moveDistance;

                // update the object's position
                transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if you collide with deactivator
        if (collision.gameObject.CompareTag("Deactivator"))
        {
            // deactivate the gear
            isActivated = false;
            rotationSpeed = 0f;
            moveDistance = 0f;
            moveSpeed = 0f;

            // change transparency and order in layer
            Color colorChange = spriteRenderer.color;
            colorChange.a = 0.6f;
            spriteRenderer.color = colorChange;
            spriteRenderer.sortingOrder = -2;

            // change tag
            gameObject.tag = "Untagged";
        }
    }
}

