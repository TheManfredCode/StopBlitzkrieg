using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Aplication
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private ClickableArea clickableArea;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private int killsToWinCount; //need to move to GameController??
        
        public override void InstallBindings()
        {
            Container.BindInstance(clickableArea).AsSingle();
            Container.BindInstance(enemySpawner).AsSingle();
            Container.BindInstance(killsToWinCount).AsSingle();
            
            Container.Bind<GameController>().AsSingle().NonLazy();
        }
    }
}