using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController2 : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float tweenTime = 1f;
    [SerializeField] LeanTweenType tweenType;
    private bool isFacingRight = true;

    [SerializeField] Transform preview1;
    [SerializeField] Transform preview2;
    [SerializeField] Transform preview3;

    public SpriteRenderer[] levels;
    Color32 red = new Color32(197, 87, 91, 255);
    Color32 blue = new Color32(75, 106, 190, 255);

    private void Awake()
    {
        // set levels unlocked with playerprefs
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel2", 0);
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].color = red;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            levels[i].color = blue;
        }

        // set player position on the map with playerprefs
        if (PlayerPrefs.GetInt("UnlockedLevel2", 0) == 2)
        {
            player.position = new Vector3(1f, player.position.y, player.position.z);
            Camera.main.transform.position = new Vector3(2, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        if (PlayerPrefs.GetInt("UnlockedLevel2", 0) == 3)
        {
            player.position = new Vector3(5.87f, player.position.y, player.position.z);
            Camera.main.transform.position = new Vector3(4, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
    }

    void Update()
    {
        // for level 1
        if (Mathf.Abs(player.position.x + 3.99f) < 0.01f)
        {
            // previews
            preview1.gameObject.SetActive(true);
            preview2.gameObject.SetActive(false);
            preview3.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.D) && levels[0].color == blue)
            {
                LeanTween.moveLocalX(player.gameObject, 1f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 2, tweenTime).setEase(tweenType);
                if (!isFacingRight)
                {
                    Flip();
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                LeanTween.moveLocalX(player.gameObject, -9f, tweenTime).setEase(tweenType);
                if (isFacingRight)
                {
                    Flip();
                }
            }
        }
        else
        {
            preview1.gameObject.SetActive(false);
        }

        // for level 2
        if (Mathf.Abs(player.position.x - 1f) < 0.01f)
        {
            // previews
            preview1.gameObject.SetActive(false);
            preview2.gameObject.SetActive(true);
            preview3.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.D) && levels[1].color == blue)
            {
                LeanTween.moveLocalX(player.gameObject, 5.87f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 4, tweenTime).setEase(tweenType);
                if (!isFacingRight)
                {
                    Flip();
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                LeanTween.moveLocalX(player.gameObject, -3.99f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 0, tweenTime).setEase(tweenType);
                if (isFacingRight)
                {
                    Flip();
                }
            }
        }
        else
        {
            preview2.gameObject.SetActive(false);
        }

        // for level 3
        if (Mathf.Abs(player.position.x - 5.87f) < 0.01f)
        {
            // previews
            preview1.gameObject.SetActive(false);
            preview2.gameObject.SetActive(false);
            preview3.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.D) && levels[2].color == blue)
            {
                LeanTween.moveLocalX(player.gameObject, 10.6f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 6, tweenTime).setEase(tweenType);
                if (!isFacingRight)
                {
                    Flip();
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                LeanTween.moveLocalX(player.gameObject, 1f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 2, tweenTime).setEase(tweenType);
                if (isFacingRight)
                {
                    Flip();
                }
            }
        }
        else
        {
            preview3.gameObject.SetActive(false);
        }
    } // end of Update()

    // flip player when moving left or right
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = player.localScale;
        localScale.x *= -1f;
        player.localScale = localScale;
    }

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
