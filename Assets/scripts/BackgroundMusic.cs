using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip music;
    private AudioSource audioSource;

    private void Start() {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();
    }
}
