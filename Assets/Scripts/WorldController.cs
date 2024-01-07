using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("Audio");

            // Destroy each audio object found
            foreach (GameObject audioObject in audioObjects)
            {
                Destroy(audioObject);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4); // load next world
        }
        if (collision.gameObject.CompareTag("Back"))
        {
            GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("Audio");

            // Destroy each audio object found
            foreach (GameObject audioObject in audioObjects)
            {
                Destroy(audioObject);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4); // load previous world
        }
    }
}
