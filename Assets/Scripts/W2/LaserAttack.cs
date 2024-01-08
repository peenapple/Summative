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
    private bool isActivated = true;

    public SpriteRenderer spriteRenderer;
    LaserAttack script;
    LaserAnimation script2;

    private void Awake()
    {
        script = GetComponent<LaserAttack>();
        script2 = GetComponent<LaserAnimation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!inactive && isActivated)
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

    // Laser rests activated for 1.5 seconds
    void Wait()
    {
        timer = 0.0f;
        gameObject.SetActive(false);
        transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        Invoke("Reactivate", inactiveDuration);
    }

    // Laser rests inactivated for 1 second
    void Reactivate()
    {
        // Reactivate the object and reset parameters
        gameObject.SetActive(true);
        inactive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if you collide with deactivator
        if (collision.gameObject.CompareTag("Deactivator"))
        {
            // change transparency and order in layer
            Color colorChange = spriteRenderer.color;
            colorChange.a = 0.3f;
            spriteRenderer.color = colorChange;
            spriteRenderer.sortingOrder = -2;

            // change tag
            gameObject.tag = "Untagged";

            Destroy(script2);
            Destroy(script);
        }
    }
}
