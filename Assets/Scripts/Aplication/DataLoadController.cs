using System.Collections;
using UI;
using UnityEngine;

namespace Aplication
{
    public class DataLoadController
    {
        private SpritesAssetBundleLoader _spritesAssetBundleLoader;
        private ScoreCoeficientLoader _scoreCoefficientLoader;
        private AppBaseInstaller _context;
        private InterfaceController _interfaceController;
        
        public DataLoadController(AppBaseInstaller context, ScoreCoeficientLoader scoreCoefficientLoader, 
            SpritesAssetBundleLoader spritesAssetBundleLoader, InterfaceController  interfaceController)
        {
            _context = context;
            _spritesAssetBundleLoader = spritesAssetBundleLoader;
            _scoreCoefficientLoader = scoreCoefficientLoader;
            _interfaceController = interfaceController;
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
            _interfaceController.HidePreloader();
        }
    }
}