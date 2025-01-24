using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField] SettingsHandler settings;
    [SerializeField] AudioMixer audioMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settings.OnMasterVolumeChange += UpdateMaster;
        settings.OnSFXVolumeChange += UpdateSFX;
        settings.OnMusicVolumeChange += UpdateMusic;
    }

    private void UpdateMaster(float volume)
    {
        audioMixer.SetFloat("Master", CalculateVolumeBySlider(volume));
    }

    private void UpdateSFX(float volume)
    {
        audioMixer.SetFloat("SFX", CalculateVolumeBySlider(volume));
    }

    private void UpdateMusic(float volume)
    {
        audioMixer.SetFloat("Music", CalculateVolumeBySlider(volume));
    }

    private float CalculateVolumeBySlider(float volume)
    {
        return Mathf.Log10(volume) * 20;
    }
}
