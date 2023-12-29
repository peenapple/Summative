using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float tweenTime = 1f;
    [SerializeField] LeanTweenType tweenType;

    void Update()
    {
        // player + camera movement with the map
        if (Mathf.Abs(player.position.x + 4.01f) < 0.01f)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                LeanTween.moveLocalX(player.gameObject, 0.965f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 2, tweenTime).setEase(tweenType);
            }
        }
        else if (Mathf.Abs(player.position.x - 0.965f) < 0.01f)
        {
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
        else if (Mathf.Abs(player.position.x - 5.825f) < 0.01f)
        {
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
    }
}
