using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private bool isMenuEnabled = false;
    public event Action<bool> OnMenuEnabled;
    [SerializeField] GameObject SecondMenu;
    [SerializeField] public AudioManager am;
    [SerializeField] Slider[] sliders;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            sliders[0].value = PlayerPrefs.GetFloat("masterVolume", 0.5f);
            sliders[1].value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
            sliders[2].value = PlayerPrefs.GetFloat("sfxVolume", 0.5f);
        }
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToggleMenu()
    {
        isMenuEnabled = !isMenuEnabled;
        SecondMenu.SetActive(isMenuEnabled);
        OnMenuEnabled?.Invoke(isMenuEnabled);
    }

    public void ItemsCombined()
    {
        am.PlaySound(SoundIndexes.Poof);       
    }

    private void OnMouseDown()
    {
        am.PlaySound(SoundIndexes.Click);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
