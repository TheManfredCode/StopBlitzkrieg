using Ads;
using SceneManagement;
using UI;
using UnityEngine;
using Zenject;

namespace Aplication
{
    public class AppBaseInstaller : MonoInstaller
    {
        [SerializeField] private LevelSceneKeysConfig _sceneKeys;

        public override void InstallBindings()
        {
            Container.BindInstance(this).AsSingle();
            Container.BindInstance(new LevelScenesController(_sceneKeys)).AsSingle();
            
            Container.Bind<InterfaceHandler>().AsSingle();
            Container.Bind<ScoreHandler>().AsSingle();
            Container.Bind<ScoreCoeficientLoader>().AsSingle();
            Container.Bind<SpritesAssetBundleLoader>().AsSingle();
            Container.Bind<EnemiesSpritesController>().AsSingle();
            Container.Bind<DataLoadController>().AsSingle();
            Container.Bind<AdsHandler>().AsSingle();
            Container.Bind<AnalyticsHandler>().AsSingle();
        }
    }
}