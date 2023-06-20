using System;
using DefaultNamespace;
using UI.UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuWindow : BaseWindow
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private ScoreView _scoreView;

        private GameController _gameController;

        public event Action SettingsButtonClicked;

        public void Init(GameController gameController)
        {
            _gameController = gameController;
            _scoreView.Init(gameController.ScoreHandler);
        }
        
        protected override void SubscribeButtons()
        {
            base.SubscribeButtons();
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        }

        protected override void UnsubscribeButtons()
        {
            base.UnsubscribeButtons();
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        }

        private void OnPlayButtonClick()
        {
            _gameController.StartGame();
            Close();
        }
        
        private void OnRestartButtonClick()
        {
            _gameController.RestartGame();
            Close();
        }
        
        private void OnSettingsButtonClick()
        {
            SettingsButtonClicked?.Invoke();
        }
    }
}