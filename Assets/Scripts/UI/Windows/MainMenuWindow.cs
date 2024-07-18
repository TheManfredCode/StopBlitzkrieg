using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MainMenuWindow : BaseWindow
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _settingsButton;

        public event Action SettingsButtonClicked;

        private InterfaceController _interfaceController;
        
        [Inject]
        private void Construct(InterfaceController interfaceController)
        {
            _interfaceController = interfaceController;
        }
        
        public void Init(GameController gameController)
        {
            //_gameController = gameController;
            //_scoreView.Init(gameController.ScoreHandler);
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
            _interfaceController.OnStartGameClick();
            Close();
        }
        
        private void OnRestartButtonClick()
        {
            _interfaceController.OnRestartGameClick();
            Close();
        }
        
        private void OnSettingsButtonClick()
        {
            SettingsButtonClicked?.Invoke();
        }
    }
}