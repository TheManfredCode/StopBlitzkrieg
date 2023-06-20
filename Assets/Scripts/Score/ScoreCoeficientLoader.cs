using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public struct RawFactsAboutCat
{
    public string fact;
    public int length;
}

public class ScoreCoeficientLoader
{
    private const string URL = "https://catfact.ninja/fact";
    private int _coeficient;

    public event Action<int> CoeficientLoaded;
    
    public int Coeficient => _coeficient;

    public IEnumerator LoadCoefitient()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            switch (request.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("[ScoreCalculator] Get coeficient data error. " + request.result);
                    break;
                case UnityWebRequest.Result.Success:
                    RawFactsAboutCat response = JsonUtility.FromJson<RawFactsAboutCat>(request.downloadHandler.text);
                    _coeficient = response.length;
                    CoeficientLoaded?.Invoke(_coeficient);
                    break;
            }
        }
    }
}