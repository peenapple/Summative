using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);

        // Use LeanTween to smoothly scale from (0, 0, 1) to (1, 1, 1) over a specified duration
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.2f);
    }

    public void Continue()
    {
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("Audio");

        // Destroy each audio object found
        foreach (GameObject audioObject in audioObjects)
        {
            Destroy(audioObject);
        }

        if (PlayerPrefs.GetInt("UnlockedLevel1", 0) < 3)
        {
            SceneManager.LoadScene("W1");
        }
        else if (PlayerPrefs.GetInt("UnlockedLevel2", 0) < 3)
        {
            SceneManager.LoadScene("W2");
        }
        else
        {
            SceneManager.LoadScene("W3");
        }
    }

    public void NewGame()
    {
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("Audio");

        // Destroy each audio object found
        foreach (GameObject audioObject in audioObjects)
        {
            Destroy(audioObject);
        }

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("W1");
    }
}
