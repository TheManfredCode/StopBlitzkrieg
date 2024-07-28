using System.Collections;
using Ads;
using UI;
using UnityEngine;

namespace Aplication
{
    public class DataLoadController
    {
        private SpritesAssetBundleLoader _spritesAssetBundleLoader;
        private ScoreCoeficientLoader _scoreCoefficientLoader;
        private AppBaseInstaller _context;
        private InterfaceHandler _interfaceHandler;
        private AdsHandler _adsHandler;
        
        public DataLoadController(AppBaseInstaller context, ScoreCoeficientLoader scoreCoefficientLoader, 
            SpritesAssetBundleLoader spritesAssetBundleLoader, InterfaceHandler  interfaceHandler, AdsHandler adsHandler)
        {
            _context = context;
            _spritesAssetBundleLoader = spritesAssetBundleLoader;
            _scoreCoefficientLoader = scoreCoefficientLoader;
            _interfaceHandler = interfaceHandler;
            _adsHandler = adsHandler;
        }

        public void StartLoadData() =>
            _context.StartCoroutine(LoadData());

        private IEnumerator LoadData()
        {
            Debug.Log("[DataLoadController] Start loading asset bundles.");
            yield return _spritesAssetBundleLoader.LoadAssetBundle();
            Debug.Log("[DataLoadController] Start loading score coeficient.");
            yield return _scoreCoefficientLoader.LoadCoefitient();
            Debug.Log("[DataLoadController]All data loaded.");
            OnDataLoaded();
        }

        private void OnDataLoaded()
        {
            _interfaceHandler.HidePreloader();
            _adsHandler.ShowBannerAd();
        }
    }
}