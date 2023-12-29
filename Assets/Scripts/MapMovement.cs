using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float tweenTime = 0.6f;
    [SerializeField] LeanTweenType tweenType;

    void Update()
    {
        if (player.position.x == -4.03f)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                LeanTween.moveLocalX(player.gameObject, 0.95f, tweenTime).setEase(tweenType);
                LeanTween.moveLocalX(Camera.main.transform.gameObject, 1, tweenTime).setEase(tweenType);
            }
        }
    }
}
