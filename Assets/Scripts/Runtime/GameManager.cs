using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] SettingsHandler settings;
    [SerializeField] AudioMixer audioMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
        uiManager.OnMenuEnabled += HandlePause;
        settings.OnMasterVolumeChange += UpdateMaster;
        settings.OnSFXVolumeChange += UpdateSFX;
        settings.OnMusicVolumeChange += UpdateMusic;
    }

    private void HandlePause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
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
