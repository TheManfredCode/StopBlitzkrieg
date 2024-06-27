using UnityEngine;
using Zenject;

namespace Test
{
    public class TestSceneInstaller :  MonoInstaller
    {
        [SerializeField] private string message;
        
        [Inject]
        private void Construct()
        {
            
        }

        public override void InstallBindings()
        {
            Container.BindInstance(new TestSceneThing(message));
            ShowLog();
        }

        private void ShowLog()
        {
            Debug.Log("[Scene] installing" );
        }
    }
}