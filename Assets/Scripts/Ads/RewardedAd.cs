using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class RewardedAd : IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private event Action AdLoadedEvent;
        private event Action AdWatchedEvent;
        private event Action AdLoadFailedEvent;
        private event Action AdShowFailedEvent;
        
        public void ShowAd(Action<bool> callback)
        {
            AdLoadedEvent += OnAdLoaded;
            AdLoadFailedEvent += OnAdFailed;
            AdShowFailedEvent += OnAdFailed;
            Advertisement.Load(AdTypes.RewardedAdId, this);

            void OnAdLoaded()
            {
                AdLoadedEvent -= OnAdLoaded;
                AdWatchedEvent += OnAdWatched;
                Advertisement.Show(AdTypes.RewardedAdId, this);
            }

            void OnAdFailed()
            {
                AdLoadFailedEvent -= OnAdFailed;
                AdShowFailedEvent -= OnAdFailed;
                callback(false);
            }
            
            void OnAdWatched()
            {
                AdLoadFailedEvent -= OnAdFailed;
                AdShowFailedEvent -= OnAdFailed;
                AdWatchedEvent -= OnAdWatched;
                callback(true);
            }
        }
        
        public void OnUnityAdsAdLoaded(string placementId)
        {
            AdLoadedEvent?.Invoke();
            Debug.Log($"[Rewarded ad] {placementId} ad loaded");
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            AdLoadFailedEvent?.Invoke();
            Debug.LogError($"[Rewarded ad] Load {placementId} ad failed - {message}");
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            AdShowFailedEvent?.Invoke();
            Debug.LogError($"[Rewarded ad] Show {placementId} ad failed - {message}");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            Debug.Log($"[Rewarded ad] Show {placementId} ad started");
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            Debug.Log($"[Rewarded ad] Show {placementId} ad clicked");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            AdWatchedEvent?.Invoke();
        }
    }
}