using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimationUp : MonoBehaviour
{
    public float minScale = 0.3142478f; // minimum scale
    public float maxScale = 0.9f; // maximum scale
    public float scaleDuration = 0.05f; // duration for scaling
    public float restDuration = 0.81488f; // duration to rest between scaling

    private float timer = 0.0f;
    private bool scalingUp = true;
    private bool upRest = false;
    private bool downRest = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (scalingUp)
        {
            // Calculate the scale for scaling up
            float t = Mathf.Clamp01(timer / scaleDuration);
            float scale = Mathf.Lerp(minScale, maxScale, t);

            // Apply the scale
            ApplyScale(scale);

            // If reached the end of scaling up duration, switch to rest
            if (timer >= scaleDuration)
            {
                timer = 0.0f;
                scalingUp = false;
                upRest = true;
                downRest = false;
            }
        }
        else if (upRest)
        {
            if (timer >= restDuration)
            {
                timer = 0.0f;
                upRest = false;
                scalingUp = false;
                downRest = false;
            }
        }
        else if (downRest)
        {
            if (timer >= restDuration)
            {
                timer = 0.0f;
                upRest = false;
                scalingUp = true;
                downRest = false;
            }
        }
        else
        {
            // Calculate the scale for scaling down
            float t = Mathf.Clamp01(timer / scaleDuration);
            float scale = Mathf.Lerp(maxScale, minScale, t);

            // Apply the scale
            ApplyScale(scale);

            // If reached the end of scaling down duration, switch to rest
            if (timer >= scaleDuration)
            {
                timer = 0.0f;
                scalingUp = false;
                upRest = false;
                downRest = true;
            }
        }
    }

    void ApplyScale(float scale)
    {
        Vector3 newScale = transform.localScale;
        newScale.y = scale;
        transform.localScale = newScale;
    }
}
