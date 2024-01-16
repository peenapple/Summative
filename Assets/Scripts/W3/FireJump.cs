using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireJump : MonoBehaviour
{
    public float moveDistance = 3f; // adjust the distance it moves
    public float moveSpeed = 3.52f; // adjust the speed
    public float position;

    private float initialPosition;
    private bool up = true;

    void Start()
    {
        initialPosition = transform.position.y; // store the initial y position
    }

    void Update()
    {
        // calculate the new y position using Mathf.Sin
        float newPosition = initialPosition + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // update the object's position
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

        if (transform.position.y >= position + moveDistance - 0.01)
        {
            if (up)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
                up = false;
            }
        }
        if (transform.position.y <= position - moveDistance + 0.01)
        {
            if (!up)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
                up = true;
            }
        }
    }
}
