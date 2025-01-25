using System;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    private float masterVolume = 1.0f;
    private float sfxVolume = 1.0f;
    private float musicVolume = 1.0f;

    public event Action<float> OnMasterVolumeChange;
    public event Action<float> OnSFXVolumeChange;
    public event Action<float> OnMusicVolumeChange;

    private void Awake()
    {
        masterVolume = PlayerPrefs.GetFloat("masterVolume", 0.5f);
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 0.5f);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 0.5f);
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        OnMasterVolumeChange?.Invoke(masterVolume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        OnSFXVolumeChange?.Invoke(sfxVolume);
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        OnMusicVolumeChange?.Invoke(musicVolume);
    }
}
