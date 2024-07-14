using UI;
using Zenject;

namespace Aplication
{
    public class AppBaseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(this).AsSingle();
            
            Container.Bind<InterfaceController>().AsSingle();
            Container.Bind<ScoreHandler>().AsSingle();
            Container.Bind<ScoreCoeficientLoader>().AsSingle();
            Container.Bind<SpritesAssetBundleLoader>().AsSingle();
            Container.Bind<EnemiesSpritesController>().AsSingle();
            Container.Bind<DataLoadController>().AsSingle();//.NonLazy();
            
        }
    }
}