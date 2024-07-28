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

        private InterfaceHandler _interfaceHandler;
        
        [Inject]
        private void Construct(InterfaceHandler interfaceHandler)
        {
            _interfaceHandler = interfaceHandler;
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
            _interfaceHandler.OnRestartGameClick();
            Close();
        }
    }
}