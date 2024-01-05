using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{
    [SerializeField] GameObject AudioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            Destroy(AudioManager);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
        if (collision.gameObject.CompareTag("Back"))
        {
            Destroy(AudioManager);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        }
    }
}
