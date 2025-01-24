using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void PrintPress()
    {
        Debug.LogWarning("HERE");
    }
}
