using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRb;
    ParticleSystem particles;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        particles = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        // spawn point
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if you collide with obstacle
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        particles.Play();
        // wait for 0.5 seconds before respawn
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;
        playerRb.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        transform.localScale = new Vector3(0.7f, 0.7f, 1);
        playerRb.simulated = true;
    }
}
