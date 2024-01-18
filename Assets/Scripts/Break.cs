using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public float uptime;
    public bool disappear;

    // Start is called before the first frame update
    void Start()
    {
        if (disappear)
        {
            StartCoroutine(Close(uptime));
        }
    }

    IEnumerator Close(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
