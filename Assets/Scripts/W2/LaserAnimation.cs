using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimation : MonoBehaviour
{
    public float minScale = 0.25f; // Minimum scale
    public float maxScale = 0.32f; // Maximum scale
    public float duration = 0.5f; // Duration for one cycle

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        // Calculate the scale based on time
        float t = Mathf.PingPong(timer, duration) / duration; // PingPong between 0 and duration
        float scale = Mathf.Lerp(minScale, maxScale, t);

        // Apply the scale
        Vector3 newScale = transform.localScale;
        newScale.y = scale;
        transform.localScale = newScale;
    }
}