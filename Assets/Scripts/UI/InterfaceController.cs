using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class InterfaceController : MonoBehaviour
    {
        [SerializeField] private WindowsController _windowsController;
        [SerializeField] private MainUI _mainUi;
        [SerializeField] private Preloader _preloader;

        public void Init(GameController gameController, EnemiesSpritesController enemiesSpritesController)
        {
            _mainUi.Init(gameController.ScoreHandler);
            _windowsController.Init(gameController, enemiesSpritesController);
        }
        
        private void OnEnable()
        {
            _preloader.gameObject.SetActive(true);
            _mainUi.MainMenuButtonClicked += _windowsController.ShowMainMenuWindow;
        }

        private void OnDisable()
        {
            _mainUi.MainMenuButtonClicked -= _windowsController.ShowMainMenuWindow;
        }

        public void HidePreloader()
        {
            _preloader.gameObject.SetActive(false);
            _windowsController.ShowMainMenuWindow();
        }
    }
}