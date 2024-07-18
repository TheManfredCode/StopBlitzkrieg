using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class FinishedLevelWindow : BaseWindow
    {
        [SerializeField] private Button _playNextLevelButton;
        [SerializeField] private Button _addButton;

        private InterfaceController _interfaceController;
        
        [Inject]
        private void Construct(InterfaceController interfaceController) =>
            _interfaceController = interfaceController;

        protected override void SubscribeButtons()
        {
            base.SubscribeButtons();
            _playNextLevelButton.onClick.AddListener(OnPlayNextLevelButtonClick);
            _addButton.onClick.AddListener(OnAddButtonClick);
        }

        protected override void UnsubscribeButtons()
        {
            base.UnsubscribeButtons();
            _playNextLevelButton.onClick.RemoveListener(OnPlayNextLevelButtonClick);
            _addButton.onClick.RemoveListener(OnAddButtonClick);
        }

        private void OnPlayNextLevelButtonClick()
        {
            _interfaceController.OnStartGameClick();
            Close();
        }

        private void OnAddButtonClick()
        {
            Close();
        }
    }
}