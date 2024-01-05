using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;

    public static AudioManager instance;

    private void Awake()
    {
        // keep music playing on scene load
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // if there already is an instance then destroy it
        }
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
