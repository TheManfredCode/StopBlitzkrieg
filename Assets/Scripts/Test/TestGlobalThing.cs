using System;
using System.Collections;
using UnityEngine;

namespace Test
{
    public class TestGlobalThing
    {
        private TestGlobalInstaller _context;
        
        public TestGlobalThing()
        {
            Debug.Log("[Global] thing constructed");
            //_context = context;
            // _context.enabled = true;
            // _context.gameObject.SetActive(true);
            // _context.StartCoroutine(WaitOneFrame());
        }
        
        private static IEnumerator WaitOneFrame()
        {
            yield return null;
            Debug.Log("COROUTINE done");
        }
    }
}