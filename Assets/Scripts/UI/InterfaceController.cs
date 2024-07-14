using System;

namespace UI
{
    public class InterfaceController : IDisposable
    {
        //private WindowsView _windowsView;
        // private MainUI _mainUi;
        //private GameObject _preloader;
        
        public event Action ShowGameOverWindowEvent;
        public event Action ShowMainMenuWindowEvent;
        public event Action HidePreloaderEvent;
        public event Action OnWindowShownEvent;
        public event Action OnStartGameClickEvent;
        public event Action OnRestartGameClickEvent;

        public InterfaceController() // must be global
        {
            //_preloader.SetActive(true);
            //_mainUi.MainMenuButtonClicked += _windowsController.ShowMainMenuWindow;
        }
        
        // public void Init(GameController gameController, EnemiesSpritesController enemiesSpritesController)
        // {
        //     //_mainUi.Init(gameController.ScoreHandler);
        //     //_windowsView.Init(gameController, enemiesSpritesController);
        // }

        public void OnStartGameClick()
        {
            OnStartGameClickEvent.Invoke();
        }

        public void OnRestartGameClick()
        {
            OnRestartGameClickEvent.Invoke();
        }
        
        public void ShowMainMenuWindow()
        {
            OnWindowShownEvent.Invoke();
            ShowMainMenuWindowEvent.Invoke();
        }

        public void ShowSettingsWindow()
        {
            OnWindowShownEvent.Invoke();
        }

        public void ShowGameOverWindow()
        {
            ShowGameOverWindowEvent.Invoke();
            OnWindowShownEvent.Invoke();
        }

        public void HidePreloader()
        {
            HidePreloaderEvent.Invoke();
            //_preloader.SetActive(false);
            //_windowsView.ShowMainMenuWindow();
        }

        public void Dispose()
        {
            //_mainUi.MainMenuButtonClicked -= _windowsController.ShowMainMenuWindow;
        }
    }
}