using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawing : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    Vector3 previousMousePosition;

    void Start()
    {
        // previous mouse position
        previousMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previousMousePosition.z = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // check for left mouse click
        {
            // get the current mouse position in the world coordinates
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0f;

            // check if the current mouse position is different from the previous position
            if (currentMousePosition != previousMousePosition)
            {
                // instantiate the prefab if the mouse has moved
                Instantiate(prefabToInstantiate, currentMousePosition, Quaternion.identity);
                // update the previous mouse position
                previousMousePosition = currentMousePosition;
            }
        }
    }
}
