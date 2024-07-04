using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;
    public AudioClip musicaDeFondo;

    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Debug.Log("Más de un AudioManager en escena");
            Destroy(gameObject);
        }
    }

    void Start(){
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicaDeFondo;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void ReproducirSonido(AudioClip audio){
        audioSource.PlayOneShot(audio);
    }

    public void PausarMusica(){
        Debug.Log("PausarMusica called");
        if (audioSource.isPlaying){
            audioSource.Pause();
            Debug.Log("Musica pausada");
        } else {
            Debug.LogWarning("AudioSource no está reproduciendo al intentar pausar.");
        }
    }

    public void ReiniciarMusica(){
        audioSource.UnPause();
        audioSource.time = 0f;
        audioSource.Play();
        Debug.Log("Musica reiniciada");
    }
}
