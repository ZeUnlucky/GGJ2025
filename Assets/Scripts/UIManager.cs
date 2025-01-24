using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false;
    public event Action<bool> OnPause;
    [SerializeField] GameObject SecondMenu;
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void TogglePause()
    {
        isPaused = !isPaused;
        SecondMenu.SetActive(isPaused);
        OnPause.Invoke(isPaused);
    }
}
