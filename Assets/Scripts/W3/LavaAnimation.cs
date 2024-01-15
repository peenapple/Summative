using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaAnimation : MonoBehaviour
{
    public float moveDistance = 3f; // adjust the distance it moves
    public float moveSpeed = 3.52f; // adjust the speed
    public float initialPosition;

    void Update()
    {
        // calculate the new x position using Mathf.Sin
        float newPosition = initialPosition + 1f * Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // update the object's position
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}

