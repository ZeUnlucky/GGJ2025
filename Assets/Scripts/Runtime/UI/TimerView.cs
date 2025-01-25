using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerTextField;
    [SerializeField] private Timer timer;
    public bool ShouldUpdateTimer = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        if (ShouldUpdateTimer)
            TimerTextField.text = timer.GameSeconds.ToString("00");  
    }
}
