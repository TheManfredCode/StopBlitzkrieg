using System;
using UnityEngine;
using Zenject;

namespace Test
{
    public class TestSceneMonobehThing : MonoBehaviour
    {
        [SerializeField] public string message;
        
        private TestGlobalThing _globalTh;

        //[Inject]
        private void Construct(TestGlobalThing globalThing)
        {
            _globalTh = globalThing;

            if (_globalTh != null)
                Debug.Log("Global Th: " + _globalTh.GetType() + " installed on scene: " + message);
        }
    }
}