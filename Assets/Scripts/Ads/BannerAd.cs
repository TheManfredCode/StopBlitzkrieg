using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class BannerAd
    {
        private AnalyticsHandler _analyticsHandler;

        public BannerAd(AnalyticsHandler analyticsHandler)
        {
            _analyticsHandler = analyticsHandler;
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        }

        public void LoadBannerAd()
        {
            BannerLoadOptions options = new BannerLoadOptions()
            {
                loadCallback = BannerLoaded,
                errorCallback = BannerLoadError
            };
            
            Advertisement.Banner.Load(AdTypes.BannerAdId, options);
        }

        public void ShowBannerAd()
        {
            BannerOptions options = new BannerOptions()
            {
                showCallback = BannerShown,
                clickCallback = BannerClicked,
                hideCallback = BannerHidden
            };
            
            Advertisement.Banner.Show(AdTypes.BannerAdId, options);
        }

        private void BannerHidden() =>
            Debug.Log($"[Banner ad] {AdTypes.BannerAdId} ad hidden");

        private void BannerShown() =>
            Debug.Log($"[Banner ad] {AdTypes.BannerAdId} ad shown");

        private void BannerClicked() =>
            _analyticsHandler.LogBannerAdClicked();

        private void BannerLoaded() =>
            ShowBannerAd();
        
        private void BannerLoadError(string errorMessage) =>
            Debug.LogError($"[Banner ad] Load {AdTypes.BannerAdId} ad failed - {errorMessage}");
    }
}