using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class AddressableSceneLoader
    {
        private bool _clearPreviousScene;
        private SceneInstance _previousLoadedScene;
        private bool _isLoaded;

        public bool IsLoaded => _isLoaded; 
        
        public void LoadAddressableLevel(string addressableKey)
        {
            if (string.IsNullOrEmpty(addressableKey)) return;

            _isLoaded = false;
            
            if (_clearPreviousScene)
            {
                Addressables.UnloadSceneAsync(_previousLoadedScene).Completed += (asyncHandle) =>
                {
                    _clearPreviousScene = false;
                    _previousLoadedScene = new SceneInstance();
                };
            }

            Addressables.LoadSceneAsync(addressableKey, LoadSceneMode.Additive).Completed += (asyncHandle) =>
            {
                _previousLoadedScene = asyncHandle.Result;
                _clearPreviousScene = true;
                _isLoaded = true;
            };
        }
    }
}