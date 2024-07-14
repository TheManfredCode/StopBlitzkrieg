using DefaultNamespace;
using UI.UIElements;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class GameOverWindoiw : BaseWindow
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private ScoreView _scoreView;

        // private GameController _gameController;
        private InterfaceController _interfaceController;
        
        [Inject]
        private void Construct(InterfaceController interfaceController)
        {
            _interfaceController = interfaceController;
            AfterConstructed();
        }
        
        private void AfterConstructed()
        {
        }
        
        public void Init(GameController gameController)
        {
            //_gameController = gameController;
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
            _interfaceController.OnRestartGameClick();
            Close();
        }
    }
}