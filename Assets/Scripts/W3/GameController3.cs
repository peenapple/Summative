using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class GameController3 : MonoBehaviour
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
    public float scrollDistance;
    public bool isL3 = false;
    public bool isPt2 = false;
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
        if (isPt2)
        {
            LeanTween.moveLocalY(Camera.main.transform.gameObject, scrollDistance, scrollSpeed);
        }
        else
        {
            LeanTween.moveLocalX(Camera.main.transform.gameObject, scrollDistance, scrollSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if you collide with obstacle
        if (!finish)
        {
            if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Saw") || collision.gameObject.CompareTag("Fireball"))
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
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex3"))
        {
            PlayerPrefs.SetInt("ReachedIndex3", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel3", PlayerPrefs.GetInt("UnlockedLevel3", 0) + 1);
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
        if (isPt2)
        {
            SceneManager.LoadScene("W3L3 (1)");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        if (isL3)
        {
            GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("Audio");

            // Destroy each audio object found
            foreach (GameObject audioObject in audioObjects)
            {
                Destroy(audioObject);
            }
        }

        SceneManager.LoadScene("W3");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        if (isPt2)
        {
            SceneManager.LoadScene("W3L3 (1)");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Time.timeScale = 1;
    }

    public void Continue()
    {
        if (isL3)
        {
            GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("Audio");

            // Destroy each audio object found
            foreach (GameObject audioObject in audioObjects)
            {
                Destroy(audioObject);
            }
        }

        SceneManager.LoadScene("W3");
        Time.timeScale = 1;
    }
}
