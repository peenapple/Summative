using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactBreaking : MonoBehaviour
{
    public bool isW3 = false;

    void Update()
    {
        if (inCamera(transform.gameObject) && isW3)
        {
            StartCoroutine(Break(1.2f)); // break after 1.2 seconds
        }
    }

    IEnumerator Break(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(transform.gameObject);
    }

    bool inCamera(GameObject obj)
    {
        // Get the object's position in viewport coordinates
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(obj.transform.position);

        // Check if the object is inside the camera view (viewport coordinates are between 0 and 1)
        return viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1;
    }
}
