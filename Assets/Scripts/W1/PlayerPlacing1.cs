using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPlacing1 : MonoBehaviour
{
    public GameObject prefabToInstantiate; 
    Vector3 previousMousePosition;
    public TextMeshProUGUI count;
    public int placeCounter = 3;

    [SerializeField] RectTransform pauseBtn;
    [SerializeField] Transform pauseMenu;
    [SerializeField] Transform endScreen;

    void Start()
    {
        // previous mouse position
        previousMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previousMousePosition.z = 0f;
    }

    void Update()
    {
        // Check for right mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            // Raycast to get the object under the mouse in 2D
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Check if the object has the "platform" tag
                if (hit.collider.CompareTag("Platform"))
                {
                    // Destroy the object
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        // if draw counter greater than 0, pause menu is not active and player places a platform
        if (Input.GetMouseButtonDown(0) && placeCounter > 0 && !pauseMenu.gameObject.activeSelf && !endScreen.gameObject.activeSelf)
        {
            // get the current mouse position in the world coordinates
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0f;

            // check if the current mouse position is different from the previous position, and if it's not on the pause button
            if (currentMousePosition != previousMousePosition && !RectTransformUtility.RectangleContainsScreenPoint(pauseBtn, currentMousePosition))
            {
                // instantiate the prefab if the mouse has moved
                Instantiate(prefabToInstantiate, currentMousePosition, Quaternion.identity);
                // update the previous mouse position
                previousMousePosition = currentMousePosition;

                // update draw counter
                placeCounter--;
                count.text = placeCounter.ToString() + "/3";
            }
        }
    }
}
