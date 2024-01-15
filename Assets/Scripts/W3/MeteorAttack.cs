using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MeteorAttack : MonoBehaviour
{
    public float restDuration = 0f; // Duration to rest before starting
    ParticleSystem particles;

    [SerializeField] float tweenTime = 6f;

    private void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(Rest(restDuration));
    }
    IEnumerator Rest(float duration)
    {
        yield return new WaitForSeconds(duration);
        LeanTween.moveLocalX(transform.gameObject, -1.7f, tweenTime);
        LeanTween.moveLocalY(transform.gameObject, -6.13f, tweenTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelPlatform") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Deactivator"))
        {
            // death effect
            particles.Play();
            transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(Die(0.5f));
        }
    }

    IEnumerator Die(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(transform.gameObject);
    }
}
