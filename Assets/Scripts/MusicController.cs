using UnityEngine;

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
        if (musicSource.isPlaying) return;
        musicSource.Play();
    }

    public void StopPlayMusic()
    {
        musicSource.Stop();
    }

    public void OnClickMusicButton()
    {
        if (musicSource.isPlaying)
        {
            StopPlayMusic();
        }
        else
        {
            PlayMusic();
        }
    }
}