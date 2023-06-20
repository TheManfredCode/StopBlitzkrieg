using System;
using System.Collections;
using System.Collections.Generic;
using Aplication;
using DefaultNamespace;
using UI;
using UnityEngine;

public class ApplicationBase : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private InterfaceController _interfaceController;
    [SerializeField] private DataLoadController _dataLoadController;
    
    private EnemiesSpritesController _enemiesSpritesController = new EnemiesSpritesController();

    private void Awake()
    {
        _dataLoadController.Init();
        _gameController.Init(_dataLoadController.ScoreCoeficientLoader);
        _enemiesSpritesController.Init(_gameController.EnemiesPool, _dataLoadController.SpritesLoader);
        _interfaceController.Init(_gameController, _enemiesSpritesController);
        
        _dataLoadController.StartLoadData();
    }

    private void OnEnable()
    {
        _dataLoadController.AllDataLoaded += OnDataLoaded;
    }

    private void OnDisable()
    {
        _dataLoadController.AllDataLoaded -= OnDataLoaded;        
    }
    
    private void OnDataLoaded()
    {
        _interfaceController.HidePreloader();
    }
}