using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace UI
{
    public class WindowsView : MonoBehaviour // must be on ui scene
    {
        [SerializeField] private MainMenuWindow _mainMenuWindow;
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private GameOverWindoiw _gameOverWindoiw;

        private List<BaseWindow> _openedWindows = new List<BaseWindow>();
        private InterfaceController _interfaceController;

        [Inject]
        private void Construct(InterfaceController interfaceController)
        {
            _interfaceController = interfaceController;
            
            AfterConstructed();
        }

        private void AfterConstructed()
        {
            _interfaceController.ShowGameOverWindowEvent += ShowGameOverWindow;
            _interfaceController.HidePreloaderEvent += OnHidePreloader;
            _interfaceController.ShowMainMenuWindowEvent += ShowMainMenuWindow;
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

        public void Init(EnemiesSpritesController spritesController)
        {
            //_settingsWindow.Init(spritesController);
            //_mainMenuWindow.Init(gameController);
            //_gameOverWindoiw.Init(gameController);
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
            CloseOtherWindows();
            window.Show();
            _openedWindows.Add(window);            
        }

        private void OnHidePreloader()
        {
            ShowMainMenuWindow();
        }

        private void CloseOtherWindows()
        {
            foreach (var window in _openedWindows)
                window.Close();
            
            _openedWindows.Clear();
        }
    }
}