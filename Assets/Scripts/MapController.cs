using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float tweenTime = 1f;
    [SerializeField] LeanTweenType tweenType;
    private bool isFacingRight = true;

    [SerializeField] Transform preview1;
    [SerializeField] Transform preview2;
    [SerializeField] Transform preview3;

    public SpriteRenderer[] levels;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].color = new Color32(197, 87, 91, 255);
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            levels[i].color = new Color32(75, 106, 190, 255);
        }
    }

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
                if (!isFacingRight)
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
                if (!isFacingRight)
                {
                    Flip();
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                LeanTween.moveLocalX(player.gameObject, -4.01f, tweenTime).setEase(tweenType);
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
                if (!isFacingRight)
                {
                    Flip();
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                LeanTween.moveLocalX(player.gameObject, 0.965f, tweenTime).setEase(tweenType);
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
