using System;
using UnityEngine;
using UnityEngine.UI;
using UI.UIElements;

namespace UI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private Button _mainMenuButton;

        public event Action MainMenuButtonClicked;
        
        public void Init(ScoreHandler scoreHandler)
        {
            _scoreView.Init(scoreHandler);
        }

        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnMainMenuButtonClicked()
        {
            MainMenuButtonClicked?.Invoke();
        }
    }
}