using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; 

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);
    }

    public void OnVolumeChange()
    {
        float volume = volumeSlider.value;
        SetVolume(volume);
    }

    private void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetVolume(volume);
        }
    }
}
