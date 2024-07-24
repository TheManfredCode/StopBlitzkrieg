using System.Collections.Generic;
using Ads;
using UI;
using UnityEngine;
using Zenject;

namespace Aplication
{
    public class AppBaseInstaller : MonoInstaller
    {
        [SerializeField] private List<string> _sceneKeys;

        public override void InstallBindings()
        {
            Container.BindInstance(this).AsSingle();
            Container.BindInstance(new LevelScenesController(_sceneKeys)).AsSingle();
            
            Container.Bind<InterfaceController>().AsSingle();
            Container.Bind<ScoreHandler>().AsSingle();
            Container.Bind<ScoreCoeficientLoader>().AsSingle();
            Container.Bind<SpritesAssetBundleLoader>().AsSingle();
            Container.Bind<EnemiesSpritesController>().AsSingle();
            Container.Bind<DataLoadController>().AsSingle();
            Container.Bind<AdsHandler>().AsSingle();
        }
    }
}