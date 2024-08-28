using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusicSource;

    public AudioClip menuMusic;
    public AudioClip level1Music;
    public AudioClip level2Music;  
    public AudioClip level3Music;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMenuMusic();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            PlayMenuMusic();
        }
    }

    public void PlayMenuMusic()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.clip = menuMusic;
        backgroundMusicSource.Play();
    }

    public void PlayLevelMusic(int level)
    {
        backgroundMusicSource.Stop();

        switch (level)
        {
            case 1:
                backgroundMusicSource.clip = level1Music;
                break;
            case 2:
                backgroundMusicSource.clip = level2Music;
                break;
            case 3:
                backgroundMusicSource.clip = level3Music;
                break;
        }

        backgroundMusicSource.Play();
    }

    public void StopLevelMusic()
    {
        backgroundMusicSource.Stop();
    }

    public void SetVolume(float volume)
    {
        backgroundMusicSource.volume = volume;
    }
}
