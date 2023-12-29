using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float tweenTime = 1f;
    [SerializeField] LeanTweenType tweenType;

    [SerializeField] Transform preview1;
    [SerializeField] Transform preview2;
    [SerializeField] Transform preview3;

    void Update()
    {
        // player + camera movement with the map for level 1
        if (Mathf.Abs(player.position.x + 4.01f) < 0.01f)
        {
            // previews
            preview1.gameObject.SetActive(true);
            preview2.gameObject.SetActive(false);
            preview3.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.D))
            {
                LeanTween.moveLocalX(player.gameObject, 0.965f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 2, tweenTime).setEase(tweenType);
            }
        }
        else
        {
            preview1.gameObject.SetActive(false);
        }

        // for level 2
        if (Mathf.Abs(player.position.x - 0.965f) < 0.01f)
        {
            // previews
            preview1.gameObject.SetActive(false);
            preview2.gameObject.SetActive(true);
            preview3.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.D))
            {
                LeanTween.moveLocalX(player.gameObject, 5.825f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 4, tweenTime).setEase(tweenType);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                LeanTween.moveLocalX(player.gameObject, -4.01f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 0, tweenTime).setEase(tweenType);
            }
        }
        else
        {
            preview2.gameObject.SetActive(false);
        }

        // for level 3
        if (Mathf.Abs(player.position.x - 5.825f) < 0.01f)
        {
            // previews
            preview1.gameObject.SetActive(false);
            preview2.gameObject.SetActive(false);
            preview3.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.D))
            {
                LeanTween.moveLocalX(player.gameObject, 10.6f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 6, tweenTime).setEase(tweenType);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                LeanTween.moveLocalX(player.gameObject, 0.965f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 2, tweenTime).setEase(tweenType);
            }
        }
        else
        {
            preview3.gameObject.SetActive(false);
        }
    } // end of Update()

    // start buttons for levels
    public void Start1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Start2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Start3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
