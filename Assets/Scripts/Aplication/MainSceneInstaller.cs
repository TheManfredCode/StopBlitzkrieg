using Zenject;

namespace Aplication
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ApplicationBase>().AsSingle().NonLazy();
        }
    }
}