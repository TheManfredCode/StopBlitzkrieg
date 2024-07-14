using System;
using UnityEngine;
using UnityEngine.UI;
using UI.UIElements;
using Zenject;

namespace UI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private Button _mainMenuButton;

        private InterfaceController _interfaceController;
        
        [Inject]
        private void Construct(InterfaceController interfaceController)
        {
            _interfaceController = interfaceController;
        }
        
        // public void Init(ScoreHandler scoreHandler)
        // {
        //     _scoreView.Init(scoreHandler);
        // }

        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnDisable()
        {
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }

        private void OnMainMenuButtonClicked()
        {
            _interfaceController.ShowMainMenuWindow();
        }
    }
}