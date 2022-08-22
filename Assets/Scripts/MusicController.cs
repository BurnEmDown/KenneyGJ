﻿using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance;

    public AudioSource musicSource;
    
    void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void StopPlayMusic()
    {
        musicSource.Stop();
    }
}