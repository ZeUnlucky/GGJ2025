using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    private float gameSeconds;
    private bool _isRunning;

    public float GameSeconds => gameSeconds;


    public event Action OnTimerEnded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameSeconds = gameSettings.GameSeconds;
        _isRunning = true;
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
        }
    }
}
