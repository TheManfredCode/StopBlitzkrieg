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

        private InterfaceController _interfaceController;
        
        [Inject]
        private void Construct(InterfaceController interfaceController)
        {
            _interfaceController = interfaceController;
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