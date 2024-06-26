using DefaultNamespace;
using UI;
using UnityEngine;
using Zenject;

namespace Aplication
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private ClickableArea clickableArea;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private WindowsController windowsController;
        [SerializeField] private MainUI mainUi;
        [SerializeField] private Preloader preloader;

        private PlayerInputController _playerInputController;
        
        public override void InstallBindings()
        {
            Container.BindInstance(new DataLoadController(this));
            Container.BindInstance(new GameController(clickableArea, enemySpawner));
            Container.BindInstance(new InterfaceController(windowsController, mainUi, preloader));
            Container.Bind<ApplicationBase>().AsSingle().NonLazy();
            _playerInputController = new PlayerInputController();
        }
    }
}