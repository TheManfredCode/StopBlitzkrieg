using DefaultNamespace;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Aplication
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private ClickableArea clickableArea;
        [SerializeField] private EnemySpawner enemySpawner;
        
        /////
        // [FormerlySerializedAs("windowsController")] [SerializeField] private WindowsView windowsView;
        // [SerializeField] private MainUI mainUi;
        // [SerializeField] private Preloader preloader;
        
        public override void InstallBindings()
        {
            Container.BindInstance(clickableArea).AsSingle();
            Container.BindInstance(enemySpawner).AsSingle();
            
            Container.Bind<GameController>().AsSingle().NonLazy();

            //Container.BindInstance(new DataLoadController(this));
            //Container.Bind<ApplicationBase>().AsSingle().NonLazy();
        }
    }
}