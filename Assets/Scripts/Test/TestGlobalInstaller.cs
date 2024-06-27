using UnityEngine;
using Zenject;

namespace Test
{
    public class TestGlobalInstaller : MonoInstaller
    {
        private TestSceneThing _th;
        
        // [Inject]
        // private void Construct(TestSceneThing th)
        // {
        //     _th = th;
        //     ShowLog();
        // }
        
        private void ShowLog()
        {
            Debug.Log("[Global] installing" + _th.Message);
        }
    }
}