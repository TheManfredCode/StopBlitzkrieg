using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpritesAssetBundleLoader
{
    private const string URL = "https://drive.google.com/uc?export=download&id=1_Zid0wezqU88n_mA3iSm7PJT3y7XfiBJ";
    private List<Sprite> _sprites;

    public event Action DataLoaded;

    public SpritesAssetBundleLoader()
    {
        _sprites = new List<Sprite>();
    }
    
    public List<Sprite> Sprites => _sprites;

    public IEnumerator LoadAssetBundle()
    {
        using (UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle(URL))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogWarning("[LoadAssetBundle] " + webRequest.error);
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(webRequest);
                var bundleObjects = bundle.LoadAllAssets();

                 foreach (var bundleObject in bundleObjects)
                     if (bundleObject is Sprite)
                         _sprites.Add(bundleObject as Sprite);

                bundle.Unload(false);
                yield return new WaitForEndOfFrame();

                DataLoaded?.Invoke();
                Debug.Log("[LoadAssetBundle] Asset bundles LOADED");
            }
            webRequest.Dispose();
        }
    }
}