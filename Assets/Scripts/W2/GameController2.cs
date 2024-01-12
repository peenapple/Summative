using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class GameController2 : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRb;
    ParticleSystem particles;

    [SerializeField] Button pause;
    [SerializeField] Transform endScreen;
    [SerializeField] Transform pauseMenu;
    [SerializeField] float tweenTime = 0.3f;
    [SerializeField] LeanTweenType tweenType;

    public int scrollSpeed;
    public int scrollDistance;
    private bool finish = false;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        particles = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        // spawn point
        startPos = transform.position;
        // main camera scrolling
        LeanTween.moveLocalY(Camera.main.transform.gameObject, scrollDistance, scrollSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if you collide with obstacle
        if (!finish)
        {
            if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Saw"))
            {
                Die();
            }
        }
        // if you collide with end flag
        if (collision.gameObject.CompareTag("Finish"))
        {
            UnlockNewLevel();
            pause.interactable = false;
            endScreen.gameObject.SetActive(true);
            LeanTween.moveLocalY(endScreen.gameObject, 0, tweenTime).setEase(tweenType);
            finish = true;
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex2"))
        {
            PlayerPrefs.SetInt("ReachedIndex2", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel2", PlayerPrefs.GetInt("UnlockedLevel2", 0) + 1);
            PlayerPrefs.Save();
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
        SceneManager.LoadScene("W2");
        Time.timeScale = 1;
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

    public void Continue()
    {
        SceneManager.LoadScene("W2");
        Time.timeScale = 1;
    }
}
