using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource audioSource;
    [Header("AudioClip")]
    [SerializeField] private AudioClip soundClick;
    [SerializeField] private AudioClip soundCountDown;
    [SerializeField] private AudioClip soundWin;
    [SerializeField] private AudioClip soundLose;
    [SerializeField] private AudioClip soundPoint;
    
    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource> ();
    }
    
    public void PlaySoundClick()
    {
        audioSource.PlayOneShot(soundClick);
    }

    public void PlaySoundCountDown()
    {       
        audioSource.PlayOneShot(soundCountDown);
    }
    
    public void PlaySoundWin()
    {       
        audioSource.PlayOneShot(soundWin);
    }
    
    public void PlaySoundLose()
    {       
        audioSource.PlayOneShot(soundLose);
    }
    
    public void PlayMatchPoint()
    {       
        audioSource.PlayOneShot(soundPoint);
    }
}



