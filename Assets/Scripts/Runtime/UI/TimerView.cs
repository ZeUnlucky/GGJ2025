using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerTextField;
    [SerializeField] private Timer timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        TimerTextField.text = timer.GameSeconds.ToString("0:00");
    }
}
