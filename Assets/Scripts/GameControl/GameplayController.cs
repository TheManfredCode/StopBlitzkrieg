using System;
using Ads;
using SceneManagement;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameplayController : IDisposable
    {
        private EnemySpawner _enemySpawner;
        private ScoreHandler _scoreHandler;
        private InterfaceHandler _interfaceHandler;
        private LevelScenesController _scenesController;
        private AnalyticsHandler _analyticsHandler;
        private AdsHandler _adsHandler;
        private readonly int _killsToWinCount;
        private int _enemiesKilled;
        private bool _isGameStarted;
        
        public GameplayController( 
            EnemySpawner enemySpawner, 
            ScoreHandler scoreHandler, 
            InterfaceHandler interfaceHandler,
            LevelScenesController scenesController,
            LevelSceneConfig sceneConfig,
            AnalyticsHandler analyticsHandler,
            AdsHandler adsHandler)
        {
            _enemySpawner = enemySpawner;
            _scoreHandler = scoreHandler;
            _interfaceHandler = interfaceHandler;
            _enemySpawner.Init();
            _scenesController = scenesController;
            _killsToWinCount = sceneConfig.KillsToWinCount;
            _analyticsHandler = analyticsHandler;
            _adsHandler = adsHandler;

            AddListeners();
        }
        
        private void AddListeners()
        {
            _scoreHandler.HardModeScoreReached += OnHardModeScoreReached;
            _enemySpawner.EnemyKilled += OnEnemyKilled;
            _interfaceHandler.OnWindowShownEvent += PauseGame;
            _interfaceHandler.OnStartGameClickEvent += StartGame;
            _interfaceHandler.OnRestartGameClickEvent += RestartGame;
        }

        private bool IsFinishLevelConditionsCompleted => _enemiesKilled == _killsToWinCount;
        
        public void OnClickableAreaExit() =>
            GameOver();

        private void OnEnemyKilled()
        {
            _scoreHandler.IncreaseScore();
            _enemiesKilled++;
            
            if(IsFinishLevelConditionsCompleted)
                OnFinishConditionsCompleted();
        }
        
        private void OnFinishConditionsCompleted()
        {
            if(_killsToWinCount > 0)
                _analyticsHandler.LogLevelSuccess(_scenesController.CurrentLevel, _scoreHandler.GetScore());
            
            _scenesController.UnlockNextLevel();
            _scenesController.LoadLastScene();
            _interfaceHandler.ShowFinishedLevelWindow();
        }
        
        private void OnHardModeScoreReached()
        {
        }

        public void StartGame()
        {
            if(!_scenesController.IsSceneLoaded)
                return;
            
            if(_isGameStarted) 
                ResumeGame();
            else
                RestartGame();
        }

        public void RestartGame()
        {
            _isGameStarted = true;
            _enemiesKilled = 0;
            _scoreHandler?.ResetScore();
            _enemySpawner.RestartPool();
            Time.timeScale = 1;
        }

        public void PauseGame() =>
            Time.timeScale = 0;

        public void ResumeGame()
        {
            _enemySpawner.IsPaused = false;
            Time.timeScale = 1;
        }
        
        private void GameOver()
        {
            _adsHandler.ShowInterstitialAd();
            
            if(_killsToWinCount > 0)
                _analyticsHandler.LogLevelFail(_scenesController.CurrentLevel, _scoreHandler.GetScore());
            
            Time.timeScale = 0;
            _interfaceHandler.ShowGameOverWindow();
        }

        public void Dispose()
        {
            _scoreHandler.HardModeScoreReached -= OnHardModeScoreReached;
            _enemySpawner.EnemyKilled -= OnEnemyKilled;
            _interfaceHandler.OnWindowShownEvent -= PauseGame;
            _interfaceHandler.OnStartGameClickEvent -= StartGame;
            _interfaceHandler.OnRestartGameClickEvent -= RestartGame;
        }
    }
}