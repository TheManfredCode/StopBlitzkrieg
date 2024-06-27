using UnityEngine;
using Zenject;

namespace Test
{
    public class TestSceneThing
    {
        public string Message { get; private set; }

        public TestSceneThing(string message)
        {
            Message = message;
        }
        
    }
}