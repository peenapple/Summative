using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMovement: MonoBehaviour
{
    public float rotationSpeed = 150f; // adjust the speed of rotation
    public float moveDistance = 3f; // adjust the distance it moves
    public float moveSpeed = 3.52f; // adjust the speed
    public float isRight = 1f;
    public float initialPosition;
    public float transparency = 0.8f;
    public SpriteRenderer spriteRenderer;

    private bool isActivated = true;

    void Start()
    {
        isActivated = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    { 
        if (isActivated)
        {
            // spin the object around its up axis (Y-axis in most cases)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            // calculate the new x position using Mathf.Sin
            float newPosition = initialPosition + isRight * Mathf.Sin(Time.time * moveSpeed) * moveDistance;

            // update the object's position
            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
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
            colorChange.a = transparency;
            spriteRenderer.color = colorChange;
            spriteRenderer.sortingOrder = -2;

            // change tag
            gameObject.tag = "Untagged";
        }
    }
}

