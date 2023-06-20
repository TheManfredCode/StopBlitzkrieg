using DefaultNamespace;
using UI.UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverWindoiw : BaseWindow
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private ScoreView _scoreView;

        private GameController _gameController;
        
        public void Init(GameController gameController)
        {
            _gameController = gameController;
            _scoreView.Init(_gameController.ScoreHandler);
        }

        protected override void SubscribeButtons()
        {
            base.SubscribeButtons();
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        protected override void UnsubscribeButtons()
        {
            base.UnsubscribeButtons();
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            _gameController.RestartGame();
            Close();
        }
    }
}