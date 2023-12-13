using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawing : MonoBehaviour
{
    public GameObject prefabToInstantiate;

    void Update()
    {
        if (Input.GetMouseButton(0)) // check for left mouse click
        {
            // get the mouse position in the world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // set the Z position to 0 to place it in the 2D space

            Instantiate(prefabToInstantiate, mousePosition, Quaternion.identity);
            // instantiate the prefab at the mouse click position with no rotation
        }
    }
}
