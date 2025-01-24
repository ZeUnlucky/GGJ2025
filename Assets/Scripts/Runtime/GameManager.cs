using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace Runtime
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] SettingsHandler settings;
        [SerializeField] AudioMixer audioMixer;
        [SerializeField] UIManager uiManager;

        [SerializeField] private GoalManager _goalManager;

        [SerializeField] private Timer _timer;

        [SerializeField] private TextMeshProUGUI _announcementTextField;

        private bool _isGameOver = false;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Time.timeScale = 1;
            settings.OnMasterVolumeChange += UpdateMaster;
            settings.OnSFXVolumeChange += UpdateSFX;
            settings.OnMusicVolumeChange += UpdateMusic;
            uiManager.OnMenuEnabled += SetMenuStatus;

            _timer.OnTimerEnded += GameOver;
            _goalManager.onCompleted += GameOver;
        }

        private void GameOver()
        {
            if (_isGameOver) return;
            //Game over
            var score = _goalManager.Score;
            _announcementTextField.text = $"Your Mom is home! You managed to hide {score} items.";
            //TODO: Stop the game and restart
        }

        private void UpdateMaster(float volume)
        {
            audioMixer.SetFloat("Master", CalculateVolumeBySlider(volume));
        }

        private void UpdateSFX(float volume)
        {
            audioMixer.SetFloat("SFX", CalculateVolumeBySlider(volume));
        }

        private void UpdateMusic(float volume)
        {
            audioMixer.SetFloat("Music", CalculateVolumeBySlider(volume));
        }

        private void SetMenuStatus(bool status)
        {
            Time.timeScale = status ? 0 : 1;
        }

        private float CalculateVolumeBySlider(float volume)
        {
            return Mathf.Log10(volume) * 20;
        }
    }
}