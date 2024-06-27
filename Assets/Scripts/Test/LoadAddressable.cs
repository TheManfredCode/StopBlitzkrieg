using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class LoadAddressable : MonoBehaviour
{
    private bool _clearPreviousScene;
    private SceneInstance _previousLoadedScene;

    public void LoadAddressableLevel(string addressableKey)
    {
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
            _clearPreviousScene = true;
            _previousLoadedScene = asyncHandle.Result;
        };
    }
}