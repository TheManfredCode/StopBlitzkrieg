using System;
using System.Collections;
using UnityEngine;

namespace Aplication
{
    public class DataLoadController : MonoBehaviour
    {
        private SpritesAssetBundleLoader _spritesAssetBundleLoader;
        private ScoreCoeficientLoader _scoreCoeficientLoader;

        public event Action AllDataLoaded;

        public SpritesAssetBundleLoader SpritesLoader => _spritesAssetBundleLoader;
        public ScoreCoeficientLoader ScoreCoeficientLoader => _scoreCoeficientLoader;

        public void Init()
        {
            _spritesAssetBundleLoader = new SpritesAssetBundleLoader();
            _scoreCoeficientLoader = new ScoreCoeficientLoader();
        }

        public void StartLoadData()
        {
            StartCoroutine(LoadData());
        }

        private IEnumerator LoadData()
        {
            Debug.Log("[DataLoadController] Start loading asset bundles.");
            yield return _spritesAssetBundleLoader.LoadAssetBundle();
            Debug.Log("[DataLoadController] Start loading score coeficient.");
            yield return _scoreCoeficientLoader.LoadCoefitient();
            Debug.Log("[DataLoadController]All data loaded.");
            AllDataLoaded?.Invoke();
        }
    }
}