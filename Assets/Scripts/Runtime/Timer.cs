using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    private float gameSeconds;

    public float GameSeconds => gameSeconds;


    public event Action OnTimerEnded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameSeconds = gameSettings.GameSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        gameSeconds -= Time.deltaTime;
        if (gameSeconds <= 0)
        {
            OnTimerEnded.Invoke();
        }
    }
}
