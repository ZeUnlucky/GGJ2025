using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool isMenuEnabled = false;
    public event Action<bool> OnMenuEnabled;
    [SerializeField] GameObject SecondMenu;

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

    public void QuitGame()
    {
        Application.Quit();
    }
}
