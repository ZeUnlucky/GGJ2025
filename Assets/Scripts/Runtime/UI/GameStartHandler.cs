using System;
using UnityEngine;

public class GameStartHandler : MonoBehaviour
{
    [SerializeField] GameObject gameStartPanel;
    public event Action StartGameEvent;

    public void StartGame()
    {
        gameStartPanel.SetActive(false);
        StartGameEvent?.Invoke();
    }
}
