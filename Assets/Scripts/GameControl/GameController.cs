using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private ClickableArea _clickableArea;
        [SerializeField] private EnemySpawner _enemySpawner;

        private ScoreHandler _scoreHandler;
        private bool _isGameStarted;

        public event Action GameOverEvent;

        public void Init(ScoreCoeficientLoader scoreCoeficientLoader)
        {
            _scoreHandler = new ScoreHandler(scoreCoeficientLoader);
        }
        
        private void OnEnable()
        {
            _enemySpawner.Init();
            _scoreHandler.HardModeScoreReached += OnHardModeScoreReached;
            _clickableArea.ClickableAreaExit += OnClickableAreaExit;
            _enemySpawner.EnemyKilled += _scoreHandler.IncreaseScore;
        }

        private void OnDisable()
        {
            _scoreHandler.HardModeScoreReached -= OnHardModeScoreReached;
            _clickableArea.ClickableAreaExit -= OnClickableAreaExit;
            _enemySpawner.EnemyKilled -= _scoreHandler.IncreaseScore;
        }

        public List<Enemy> EnemiesPool => _enemySpawner.EnemiesPool;

        public ScoreHandler ScoreHandler => _scoreHandler;

        private void OnClickableAreaExit()
        {
            GameOver();
        }

        private void OnHardModeScoreReached()
        {
            _enemySpawner.SwitchHardMode(true);
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
            GameOverEvent?.Invoke();
        }
    }
}