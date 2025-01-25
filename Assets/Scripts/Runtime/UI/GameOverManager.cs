using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI _gameOverText;

    public void FinishGame(int score)
    {
        GameOverPanel.SetActive(true);
        _gameOverText.text = $"Mom is home! You got {score} things hidden!";
    }
}
