using System;
using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class InterfaceController : IDisposable
    {
        private WindowsController _windowsController;
        private MainUI _mainUi;
        private Preloader _preloader;

        public InterfaceController(WindowsController windowsController, MainUI mainUi, Preloader preloader)
        {
            _windowsController = windowsController;
            _mainUi = mainUi;
            _preloader = preloader;
            
            _preloader.gameObject.SetActive(true);
            _mainUi.MainMenuButtonClicked += _windowsController.ShowMainMenuWindow;
        }
        
        public void Init(GameController gameController, EnemiesSpritesController enemiesSpritesController)
        {
            _mainUi.Init(gameController.ScoreHandler);
            _windowsController.Init(gameController, enemiesSpritesController);
        }

        public void HidePreloader()
        {
            _preloader.gameObject.SetActive(false);
            _windowsController.ShowMainMenuWindow();
        }

        public void Dispose()
        {
            _mainUi.MainMenuButtonClicked -= _windowsController.ShowMainMenuWindow;
        }
    }
}