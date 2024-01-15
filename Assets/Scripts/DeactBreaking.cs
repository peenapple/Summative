using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactBreaking : MonoBehaviour
{
    public bool isW3 = false;

    private void Start()
    {
        transform.gameObject.SetActive(true);
    }

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
        transform.gameObject.SetActive(false);
    }
}
