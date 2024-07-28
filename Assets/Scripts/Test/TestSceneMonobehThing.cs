using System;
using Ads;
using UnityEngine;
using Zenject;

namespace Test
{
    public class TestSceneMonobehThing : MonoBehaviour
    {
        [SerializeField] public string message;
        
        private TestGlobalThing _globalTh;
        private AnalyticsHandler _analyticsHandler;
        private AdsHandler _adsHandler;

        //[Inject]
        private void Construct(TestGlobalThing globalThing)
        {
            _globalTh = globalThing;

            if (_globalTh != null)
                Debug.Log("Global Th: " + _globalTh.GetType() + " installed on scene: " + message);
        }

        private void Awake()
        {
            //_adsHandler = new AdsHandler();
            _analyticsHandler = new AnalyticsHandler();
        }

        public void ShowAd()
        {
            _adsHandler.ShowRewardedAd((bool bl) => { Debug.Log("ad - " + bl);});
        }

        public void LogTestAnalyticsEvent()
        {
            //_analyticsHandler.LogEvent();
            Debug.Log("TEST ANALYTIC SENT");
        }
    }
}