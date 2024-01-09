using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPlacing2 : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject deactPrefab;
    Vector3 previousMousePosition;

    public TextMeshProUGUI platCount;
    public TextMeshProUGUI deactCount;

    private int platCounter = 20;
    private int deactCounter = 3;
    private bool platActive = true;
    private bool deactActive = false;

    [SerializeField] RectTransform pauseBtn;
    [SerializeField] Transform pauseMenu;
    [SerializeField] Transform endScreen;
    [SerializeField] Transform border1;
    [SerializeField] Transform border2;

    void Start()
    {
        // previous mouse position
        previousMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previousMousePosition.z = 0f;
        platActive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            platActive = true;
            deactActive = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            deactActive = true;
            platActive = false;
        }

        // for platforms
        if (platActive)
        {
            border1.gameObject.SetActive(true);
            border2.gameObject.SetActive(false);

            // if draw counter greater than 0, pause menu is not active and player places a platform
            if (Input.GetMouseButtonDown(0) && platCounter > 0 && !pauseMenu.gameObject.activeSelf && !endScreen.gameObject.activeSelf)
            {
                // get the current mouse position in the world coordinates
                Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentMousePosition.z = 0f;

                // check if the current mouse position is different from the previous position, and if it's not on the pause button
                if (currentMousePosition != previousMousePosition && !RectTransformUtility.RectangleContainsScreenPoint(pauseBtn, currentMousePosition))
                {
                    // instantiate the prefab if the mouse has moved
                    Instantiate(platformPrefab, currentMousePosition, Quaternion.identity);
                    // update the previous mouse position
                    previousMousePosition = currentMousePosition;

                    // update draw counter
                    platCounter--;
                    platCount.text = platCounter.ToString() + "/20";
                }
            }
        }

        // for deactivator
        if (deactActive)
        {
            border1.gameObject.SetActive(false);
            border2.gameObject.SetActive(true);

            if (Input.GetMouseButtonDown(0) && deactCounter > 0 && !pauseMenu.gameObject.activeSelf && !endScreen.gameObject.activeSelf)
            {
                Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentMousePosition.z = 0f;

                if (currentMousePosition != previousMousePosition && !RectTransformUtility.RectangleContainsScreenPoint(pauseBtn, currentMousePosition))
                {
                    Instantiate(deactPrefab, currentMousePosition, Quaternion.identity);
                    previousMousePosition = currentMousePosition;

                    deactCounter--;
                    deactCount.text = deactCounter.ToString() + "/3";
                }
            }
        }
    }
}
