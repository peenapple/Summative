using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimation : MonoBehaviour
{
    public float moveDistance = 3.2f; // adjust the distance it moves
    public float moveSpeed = 3.6f; // adjust the speed
    private float initialPosition;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position.y; // store the initial y position
        StartCoroutine(Rest(0.2f));
    }
    IEnumerator Rest(float duration)
    {
        yield return new WaitForSeconds(duration);
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            // calculate the new y position using Mathf.Sin
            float newPosition = initialPosition + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

            // update the object's position
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        }
    }
}
