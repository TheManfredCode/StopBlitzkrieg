using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace UI
{
    public class WindowsView : MonoBehaviour 
    {
        [SerializeField] private MainMenuWindow _mainMenuWindow;
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private GameOverWindoiw _gameOverWindoiw;
        [SerializeField] private FinishedLevelWindow _finishedLevelWindow;

        private List<BaseWindow> _openedWindows = new List<BaseWindow>();
        private InterfaceHandler _interfaceHandler;

        [Inject]
        private void Construct(InterfaceHandler interfaceHandler)
        {
            _interfaceHandler = interfaceHandler;
            
            AfterConstructed();
        }

        private void AfterConstructed()
        {
            _interfaceHandler.ShowGameOverWindowEvent += ShowGameOverWindow;
            _interfaceHandler.ShowMainMenuWindowEvent += ShowMainMenuWindow;
            _interfaceHandler.ShowFinishedLevelWindowEvent += ShowFinishedLevelWindow;
        }
        
        private void OnEnable()
        {
            _settingsWindow.Closed += ShowMainMenuWindow;
            _mainMenuWindow.SettingsButtonClicked += ShowSettingsWindow;
        }

        private void OnDisable()
        {
            _settingsWindow.Closed -= ShowMainMenuWindow;
            _mainMenuWindow.SettingsButtonClicked -= ShowSettingsWindow;
        }

        public void ShowMainMenuWindow()
        { 
            ShowWindow(_mainMenuWindow);
        }

        public void ShowSettingsWindow()
        {
            ShowWindow(_settingsWindow);
        }

        private void ShowGameOverWindow()
        {
            ShowWindow(_gameOverWindoiw);
        }

        private void ShowFinishedLevelWindow()
        {
            ShowWindow(_finishedLevelWindow);
        }

        private void ShowWindow(BaseWindow window)
        {
            CloseOtherWindows();
            window.Show();
            _openedWindows.Add(window);            
        }

        private void CloseOtherWindows()
        {
            foreach (var window in _openedWindows)
                window.Close();
            
            _openedWindows.Clear();
        }
    }
}