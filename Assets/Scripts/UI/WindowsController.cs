using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class WindowsController : MonoBehaviour
    {
        [SerializeField] private MainMenuWindow _mainMenuWindow;
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private GameOverWindoiw _gameOverWindoiw;

        private List<BaseWindow> _openedWindows = new List<BaseWindow>();
        private GameController _gameController;
        
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

        public void Init(GameController gameController, EnemiesSpritesController spritesController)
        {
            _gameController = gameController;
            _gameController.GameOverEvent += ShowGameOverWindow;

            _settingsWindow.Init(spritesController);
            _mainMenuWindow.Init(gameController);
            _gameOverWindoiw.Init(gameController);
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

        private void ShowWindow(BaseWindow window)
        {
            _gameController.PauseGame();
            CloseOtherWindows();
            window.Show();
            _openedWindows.Add(window);            
        }

        private void CloseOtherWindows()
        {
            foreach (var window in _openedWindows)
                window.Close();
            
            _openedWindows = new List<BaseWindow>();
        }
    }
}