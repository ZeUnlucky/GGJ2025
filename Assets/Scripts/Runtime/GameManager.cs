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
        [SerializeField] TimerView timerView;
        [SerializeField] GameOverManager gameOverManager;
        [SerializeField] GameStartHandler gameStartHandler;

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
            gameStartHandler.StartGameEvent += StartGame;

            _timer.OnTimerEnded += GameOver;
            _goalManager.onCompleted += GameOver;
        }

        public void StartGame()
        {
            timerView.timer.StartGame();
        }
        private void GameOver()
        {
            if (_isGameOver) return;
            _isGameOver = true;
            timerView.ShouldUpdateTimer = false;
            //Game over
            gameOverManager.FinishGame(_goalManager.Score);
            Time.timeScale = 0;
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