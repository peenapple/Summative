using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactBreaking : MonoBehaviour
{
    public bool isW3 = false;

    void Update()
    {
        if (isW3)
        {
            StartCoroutine(Break(1.2f)); // break after 1.2 seconds
        }
    }

    IEnumerator Break(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(transform.gameObject);
    }
}
