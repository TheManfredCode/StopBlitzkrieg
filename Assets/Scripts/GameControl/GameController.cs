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
        
        public GameController(ClickableArea clickableArea, 
            EnemySpawner enemySpawner, 
            ScoreHandler scoreHandler, 
            InterfaceController interfaceController)
        {
            _clickableArea = clickableArea;
            _enemySpawner = enemySpawner;
            _scoreHandler = scoreHandler;
            _interfaceController = interfaceController;
            _enemySpawner.Init();

            AddListeners();
        }

        // public void Init(ScoreCoeficientLoader scoreCoeficientLoader)
        // {
        //     //_scoreHandler = new ScoreHandler(scoreCoeficientLoader); // must be global
        //     //InitSubscriptions();
        // }
        
        private void AddListeners()
        {
            _scoreHandler.HardModeScoreReached += OnHardModeScoreReached;
            _clickableArea.ClickableAreaExit += OnClickableAreaExit;
            _enemySpawner.EnemyKilled += _scoreHandler.IncreaseScore;
            _interfaceController.OnWindowShownEvent += PauseGame;
            _interfaceController.OnStartGameClickEvent += StartGame;
            _interfaceController.OnRestartGameClickEvent += RestartGame;
        }

        public List<Enemy> EnemiesPool => _enemySpawner.EnemiesPool;
        
        private void OnClickableAreaExit()
        {
            //TODO return game over
            //GameOver();
        }

        private void OnHardModeScoreReached()
        {
            //_enemySpawner.SwitchHardMode(true);
        }

        public void StartGame()
        {
            if(_isGameStarted) ResumeGame();

            _enemySpawner.IsPaused = false;
            Time.timeScale = 1;
            _isGameStarted = true;
        }

        public void RestartGame()
        {
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
            _enemySpawner.EnemyKilled -= _scoreHandler.IncreaseScore;
        }
    }
}