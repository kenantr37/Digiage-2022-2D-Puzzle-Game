using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ButtonSound()
    {
        audioSource.PlayOneShot(clips[0]);
    }
    public void MirrorPuttingSound()
    {
        audioSource.PlayOneShot(clips[1]);
    }
    public void SlideScreen()
    {
        audioSource.PlayOneShot(clips[2]);
    }
    public void FinishSound()
    {
        audioSource.PlayOneShot(clips[3]);
    }
}
