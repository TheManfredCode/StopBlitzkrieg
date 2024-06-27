using System;
using System.Collections;
using System.Collections.Generic;
using Aplication;
using DefaultNamespace;
using UI;
using UnityEngine;

public class ApplicationBase : IDisposable
{
    private GameController _gameController;
    private InterfaceController _interfaceController;
    private DataLoadController _dataLoadController;
    
    private EnemiesSpritesController _enemiesSpritesController = new EnemiesSpritesController();

    public ApplicationBase(DataLoadController dataLoadController, InterfaceController interfaceController, GameController gameController)
    {
        _dataLoadController = dataLoadController;
        _interfaceController = interfaceController;
        _gameController = gameController;
        
        Debug.Log($"[ApplicationBase] Created. data controller - {dataLoadController.GetType()}");
        
        Init();
    }
    
    private void Init()
    {
        _dataLoadController.Init();
        _gameController.Init(_dataLoadController.ScoreCoeficientLoader);
        _enemiesSpritesController.Init(_gameController.EnemiesPool, _dataLoadController.SpritesLoader);
        _interfaceController.Init(_gameController, _enemiesSpritesController);
        _dataLoadController.AllDataLoaded += OnDataLoaded;
        _dataLoadController.StartLoadData();
        Ticker.Init();
    }

    private void OnDataLoaded()
    {
        _interfaceController.HidePreloader();
    }

    public void Dispose()
    {
        _dataLoadController.AllDataLoaded -= OnDataLoaded;
    }
}