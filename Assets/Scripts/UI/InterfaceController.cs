using System;

namespace UI
{
    public class InterfaceController : IDisposable
    {
        public event Action ShowGameOverWindowEvent;
        public event Action ShowMainMenuWindowEvent;
        public event Action ShowFinishedLevelWindowEvent;
        public event Action HidePreloaderEvent;
        public event Action OnWindowShownEvent;
        public event Action OnStartGameClickEvent;
        public event Action OnRestartGameClickEvent;

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

        public void ShowFinishedLevelWindow()
        {
            ShowFinishedLevelWindowEvent.Invoke();
            OnWindowShownEvent.Invoke();
        }

        public void HidePreloader()
        {
            HidePreloaderEvent.Invoke();
            ShowMainMenuWindow();
        }

        public void Dispose()
        {
            //_mainUi.MainMenuButtonClicked -= _windowsController.ShowMainMenuWindow;
        }
    }
}