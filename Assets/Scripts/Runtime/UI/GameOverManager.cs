using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private TextMeshProUGUI _gameOverChangingButtonText;
    private bool _isGameWon = false;

    public void FinishGame(int score, bool didWin)
    {
        GameOverPanel.SetActive(true);
        
        _isGameWon= didWin;
        if (_isGameWon)
        {
            _gameOverText.text = $"Everything looks fine!";
            _gameOverChangingButtonText.text = "Next Level";
        }
        else
        {
            _gameOverText.text = $"Busted!";
            _gameOverChangingButtonText.text = "Retry Level";
        }
    }

    public void ChangingButtonHandler()
    {
        if (!_isGameWon)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
