using System;
using SceneManagement;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameController : IDisposable
    {
        private ClickableArea _clickableArea;
        private EnemySpawner _enemySpawner;
        private ScoreHandler _scoreHandler;
        private InterfaceController _interfaceController;
        private LevelScenesController _scenesController;
        private AnalyticsHandler _analyticsHandler;
        private readonly int _killsToWinCount;
        private int _enemiesKilled;
        private bool _isGameStarted;
        
        public GameController(ClickableArea clickableArea, 
            EnemySpawner enemySpawner, 
            ScoreHandler scoreHandler, 
            InterfaceController interfaceController,
            LevelScenesController scenesController,
            LevelSceneConfig sceneConfig,
            AnalyticsHandler analyticsHandler)
        {
            _clickableArea = clickableArea;
            _enemySpawner = enemySpawner;
            _scoreHandler = scoreHandler;
            _interfaceController = interfaceController;
            _enemySpawner.Init();
            _scenesController = scenesController;
            _killsToWinCount = sceneConfig.KillsToWinCount;
            _analyticsHandler = analyticsHandler;

            AddListeners();
        }
        
        private void AddListeners()
        {
            _scoreHandler.HardModeScoreReached += OnHardModeScoreReached;
            _clickableArea.ClickableAreaExit += OnClickableAreaExit;
            _enemySpawner.EnemyKilled += OnEnemyKilled;
            _interfaceController.OnWindowShownEvent += PauseGame;
            _interfaceController.OnStartGameClickEvent += StartGame;
            _interfaceController.OnRestartGameClickEvent += RestartGame;
        }

        private bool IsFinishLevelConditionsCompleted => _enemiesKilled == _killsToWinCount;
        
        private void OnClickableAreaExit() =>
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
            _interfaceController.ShowFinishedLevelWindow();
        }
        
        private void OnHardModeScoreReached()
        {
            //TODO return hardmode
            //_enemySpawner.SwitchHardMode(true);
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
            if(_killsToWinCount > 0)
                _analyticsHandler.LogLevelFail(_scenesController.CurrentLevel, _scoreHandler.GetScore());
            
            Time.timeScale = 0;
            _interfaceController.ShowGameOverWindow();
        }

        public void Dispose()
        {
            _scoreHandler.HardModeScoreReached -= OnHardModeScoreReached;
            _clickableArea.ClickableAreaExit -= OnClickableAreaExit;
            _enemySpawner.EnemyKilled -= OnEnemyKilled;
            _interfaceController.OnWindowShownEvent -= PauseGame;
            _interfaceController.OnStartGameClickEvent -= StartGame;
            _interfaceController.OnRestartGameClickEvent -= RestartGame;
        }
    }
}