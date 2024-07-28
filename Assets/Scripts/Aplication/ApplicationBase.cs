using Aplication;
using UnityEngine;

public class ApplicationBase
{
    public ApplicationBase(DataLoadController dataLoadController)
    {
        dataLoadController.StartLoadData();
        Debug.Log($"[ApplicationBase] Created. data controller - {dataLoadController.GetType()}");
        
        Ticker.Init();
    }
}