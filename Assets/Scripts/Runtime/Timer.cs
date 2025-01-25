using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    [SerializeField] public UnityEvent timerStarted;
    [SerializeField] public UnityEvent timerEnded;
    private float gameSeconds;
    private bool _isRunning;

    public float GameSeconds => gameSeconds;


    public event Action OnTimerEnded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isRunning) return;    
        gameSeconds -= Time.deltaTime;
        if (gameSeconds <= 0)
        {
            _isRunning = false;
            OnTimerEnded.Invoke();
            timerEnded.Invoke();
        }
    }

    public void StartGame()
    {
        gameSeconds = gameSettings.GameSeconds;
        timerStarted.Invoke();
        _isRunning = true;
    }
}
