using UnityEngine;
using Zenject;

namespace Test
{
    public class TestSceneThing
    {
        private TestGlobalThing _globalTh;

        public TestSceneThing(TestGlobalThing globalThing, TestSceneMonobehThing monobehThing)
        {
            _globalTh = globalThing;

            if (_globalTh != null)
                Debug.Log("Global Th: " + _globalTh.GetType() + " installed on scene: " + monobehThing.message);
        }

        public void ShowMessage(string message)
        {
            Debug.Log("Global Th: " + _globalTh.GetType() + " CALLED on scene: " + message);
            
        }
    }
}