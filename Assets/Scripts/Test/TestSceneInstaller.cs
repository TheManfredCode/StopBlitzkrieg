using UnityEngine;
using Zenject;

namespace Test
{
    public class TestSceneInstaller :  MonoInstaller
    {
        [SerializeField] private string message;
        [SerializeField] private TestSceneMonobehThing _monobehThing; 

        private TestSceneThing _scth;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_monobehThing).AsSingle();
            Container.Bind<TestSceneThing>().AsSingle().NonLazy();
        }

        private void ShowLog()
        {
            //Debug.Log("[Scene] installer installed" );
        }
    }
}