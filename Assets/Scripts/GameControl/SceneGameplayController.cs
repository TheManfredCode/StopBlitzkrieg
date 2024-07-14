using System;

namespace DefaultNamespace
{
    public class SceneGameplayController
    {
        private ClickableArea _clickableArea;
        private EnemySpawner _enemySpawner;
        private ScoreHandler _scoreHandler;
        private bool _isGameStarted;

        //public event Action GameOverEvent;

        public SceneGameplayController(ClickableArea clickableArea, EnemySpawner enemySpawner)
        {
            _clickableArea = clickableArea;
            _enemySpawner = enemySpawner;
        }
    }
}