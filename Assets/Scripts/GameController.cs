using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRb;
    ParticleSystem particles;

    [SerializeField] Transform endScreen;
    [SerializeField] Transform pauseMenu;
    [SerializeField] float tweenTime = 0.3f;
    [SerializeField] LeanTweenType tweenType;

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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
        // if you collide with end flag
        if (collision.gameObject.CompareTag("Finish"))
        {
            LeanTween.moveLocalY(endScreen.gameObject, 0, tweenTime).setEase(tweenType);
        }
    }

    void Die()
    {
        // death effect
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        // go to home
    }

    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
