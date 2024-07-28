using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class InterstitialAd : IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private AnalyticsHandler _analyticsHandler;
        private event Action AdLoadedEvent;

        public InterstitialAd(AnalyticsHandler analyticsHandler)
        {
            _analyticsHandler = analyticsHandler;
        }

        public void ShowAd()
        {
            AdLoadedEvent += OnAdLoaded;
            Advertisement.Load(AdTypes.InterstitialAdId, this);

            void OnAdLoaded()
            {
                AdLoadedEvent -= OnAdLoaded;
                Advertisement.Show(AdTypes.InterstitialAdId, this);
            }
        }
        
        public void OnUnityAdsAdLoaded(string placementId)
        {
            AdLoadedEvent?.Invoke();
            Debug.Log($"[Interstitial ad] {placementId} ad loaded");
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) =>
            Debug.LogError($"[Interstitial ad] Load {placementId} ad failed - {message}");

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) =>
            Debug.LogError($"[Interstitial ad] Show {placementId} ad failed - {message}");

        public void OnUnityAdsShowStart(string placementId) =>
            Debug.Log($"[Interstitial ad] Show {placementId} ad started");

        public void OnUnityAdsShowClick(string placementId)
        {
            Debug.Log($"[Interstitial ad] Show {placementId} ad clicked");
            _analyticsHandler.LogInterstitialAdClicked();
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) { }
    }
}