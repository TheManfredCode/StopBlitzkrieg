using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesAssetBundleLoader
{
    private const string URL = "https://drive.google.com/uc?export=download&id=1fBxgF0Yb1q2_h7b926zGNHl0wSdW_tuc";
    private List<Sprite> _sprites;

    public event Action DataLoaded;

    public SpritesAssetBundleLoader()
    {
        _sprites = new List<Sprite>();
    }
    
    public List<Sprite> Sprites => _sprites;

    public IEnumerator LoadSprites()
    {
        WWW webRequest = new WWW(URL);

        yield return webRequest;

        while (webRequest.isDone == false)
        {
            yield return null;
        }

        if (webRequest.error == null)
        {
            var bundleObjects = webRequest.assetBundle.LoadAllAssetsAsync().allAssets;
            
            foreach (var bundleObject in bundleObjects)
                if (bundleObject is Sprite)
                    _sprites.Add(bundleObject as Sprite);

            DataLoaded?.Invoke();
            Debug.Log("[LoadAssetBundle] Asset bundles LOADED");
        }
        else
        {
            Debug.LogError("[LoadAssetBundle] " + webRequest.error);
        }
    }
}