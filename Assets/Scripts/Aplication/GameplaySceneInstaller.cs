using DefaultNamespace;
using SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Aplication
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelSceneConfig _sceneConfig;
        [SerializeField] private ClickableArea _clickableArea;
        [SerializeField] private EnemySpawner _enemySpawner;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_sceneConfig).AsSingle();
            Container.BindInstance(_clickableArea).AsSingle();
            Container.BindInstance(_enemySpawner).AsSingle();
            
            Container.Bind<GameController>().AsSingle().NonLazy();
        }
    }
}