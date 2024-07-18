using System;
using System.Collections.Generic;
using Aplication;
using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameController : IDisposable
    {
        private ClickableArea _clickableArea;
        private EnemySpawner _enemySpawner;
        private ScoreHandler _scoreHandler;
        private bool _isGameStarted;
        private InterfaceController _interfaceController;
        private LevelScenesController _scenesController;
        private int _killsToWinCount;
        private int _enemiesKilled;
        
        public GameController(ClickableArea clickableArea, 
            EnemySpawner enemySpawner, 
            ScoreHandler scoreHandler, 
            InterfaceController interfaceController,
            LevelScenesController scenesController,
            int killsToWinCount)
        {
            _clickableArea = clickableArea;
            _enemySpawner = enemySpawner;
            _scoreHandler = scoreHandler;
            _interfaceController = interfaceController;
            _enemySpawner.Init();
            _scenesController = scenesController;
            _killsToWinCount = killsToWinCount;

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
        
        private void OnClickableAreaExit()
        {
            //TODO return game over
            //GameOver();
        }

        private void OnEnemyKilled()
        {
            _scoreHandler.IncreaseScore();
            _enemiesKilled++;
            
            if(IsFinishLevelConditionsCompleted)
                OnFinishConditionsCompleted();
        }
        
        private void OnFinishConditionsCompleted()
        {
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

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            _enemySpawner.IsPaused = false;
            Time.timeScale = 1;
        }
        
        private void GameOver()
        {
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