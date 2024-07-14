using UnityEngine;
using Zenject;

namespace Test
{
    public class TestGlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(this).AsSingle();
            
            Container.Bind<TestGlobalThing>().AsSingle();
            //ShowLog();
        }

        private void ShowLog()
        {
            Debug.Log("[Global] installed");
        }
    }
}