using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    public float minXScale = 0f; // Minimum X-scale
    public float maxXScale = 10.5f; // Maximum X-scale
    public float animationDuration = 0.8f; // Duration for one cycle
    public float waitDuration = 1.5f; // Duration to wait
    public float inactiveDuration = 1.0f; // Duration to stay inactive

    private float timer = 0.0f;
    private bool inactive = false;

    void Update()
    {
        if (!inactive)
        {
            timer += Time.deltaTime;

            // Calculate the scale based on time
            float t = Mathf.PingPong(timer, animationDuration) / animationDuration;
            float scale = Mathf.Lerp(minXScale, maxXScale, t);

            // Apply the scale
            Vector3 newScale = transform.localScale;
            newScale.x = scale;
            transform.localScale = newScale;

            // If reached the end of animation duration, make it inactive
            if (timer >= animationDuration)
            {
                inactive = true;
                Invoke("Wait", waitDuration);
            }
        }
    }

    void Wait()
    {
        timer = 0.0f;
        gameObject.SetActive(false);
        transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        Invoke("Reactivate", inactiveDuration);
    }

    void Reactivate()
    {
        // Reactivate the object and reset parameters
        gameObject.SetActive(true);
        inactive = false;
    }
}
