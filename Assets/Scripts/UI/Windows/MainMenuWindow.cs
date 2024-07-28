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
        [SerializeField] private Button _clearPrefsButton;

        public event Action SettingsButtonClicked;

        private InterfaceHandler _interfaceHandler;
        
        [Inject]
        private void Construct(InterfaceHandler interfaceHandler)
        {
            _interfaceHandler = interfaceHandler;
        }

        protected override void SubscribeButtons()
        {
            base.SubscribeButtons();
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
            _clearPrefsButton.onClick.AddListener(OnClearPlayerPrefs);
        }

        protected override void UnsubscribeButtons()
        {
            base.UnsubscribeButtons();
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
            _clearPrefsButton.onClick.RemoveListener(OnClearPlayerPrefs);
        }

        private void OnPlayButtonClick()
        {
            _interfaceHandler.OnStartGameClick();
            Close();
        }
        
        private void OnRestartButtonClick()
        {
            _interfaceHandler.OnRestartGameClick();
            Close();
        }
        
        private void OnSettingsButtonClick() =>
            SettingsButtonClicked?.Invoke();
        
        public void OnClearPlayerPrefs() => 
            PlayerPrefs.DeleteAll();
    }
}