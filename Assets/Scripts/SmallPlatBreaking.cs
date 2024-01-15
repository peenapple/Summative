using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmallPlatBreaking : MonoBehaviour
{
    public Sprite newSprite;
    public Vector3 newScale = new Vector3(0.31f, 0.31f, 1f);

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Saw"))
        {
            spriteRenderer.sprite = newSprite; // change sprite
            transform.localScale = newScale; // change scale
            boxCollider.size = new Vector2(5.8f, 0.66f); // change boxcollider

            StartCoroutine(Break(0.8f)); // break after 0.8 seconds
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.sprite = newSprite; // change sprite
            transform.localScale = newScale; // change scale
            boxCollider.size = new Vector2(5.8f, 0.66f); // change boxcollider

            StartCoroutine(Break(1.2f)); // break after 2 seconds
        }
    }

    IEnumerator Break(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(transform.gameObject);
    }
}
