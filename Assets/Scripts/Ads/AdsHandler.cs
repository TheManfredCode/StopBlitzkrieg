using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public static class AdTypes
    {
#if UNITY_IOS
        public const string RewardedAdId = "Rewarded_iOS";
        public const string BannerAdId = "Banner_iOS";
        public const string InterstitialAdId = "Interstitial_iOS";
#else
        public const string RewardedAdId = "Rewarded_Android";
        public const string BannerAdId = "Banner_Android";
        public const string InterstitialAdId = "Interstitial_Android";
#endif
    }
    
    public class AdsHandler : IUnityAdsInitializationListener
    {
#if UNITY_IOS
        private const string GameId = "5661772";
#else
        private const string GameId = "5661773";
#endif
        private bool _isInitialized;
        private RewardedAd _rewardedAd;

        public AdsHandler(AnalyticsHandler analyticsHandler)
        {
            _rewardedAd = new RewardedAd(analyticsHandler);
            Advertisement.Initialize(GameId, true, this);
        }

        public void OnInitializationComplete() =>
            _isInitialized = true;

        public void OnInitializationFailed(UnityAdsInitializationError error, string message) =>
            Debug.LogError($"[AdsManager] Initialize ads failed - {message}");

        public void ShowRewardedAd(Action<bool> callback)
        {
            if (!_isInitialized) return;
            
            _rewardedAd.ShowAd(callback);
        }
    }
}