using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaWaves : MonoBehaviour
{
    [SerializeField] float tweenTime = 120f;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalX(transform.gameObject, -335, tweenTime);
    }
}
