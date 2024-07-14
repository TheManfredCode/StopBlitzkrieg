using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class SettingsWindow : BaseWindow
    {
        [SerializeField] private Button _nextSpriteButton;
        [SerializeField] private Button _previousSpriteButton;
        [SerializeField] private Image _currentSpriteView;

        private EnemiesSpritesController _spritesController;

        [Inject]
        private void Construct(EnemiesSpritesController spritesController)
        {
            _spritesController = spritesController;
            
            AfterConstructed();
        }

        private void AfterConstructed()
        {
             _spritesController.DataLoaded += OnDataLoaded;
        }
        
        public void Init(EnemiesSpritesController spritesController)
        {
            // _spritesController = spritesController;
            // _spritesController.DataLoaded += OnDataLoaded;
        }
        
        protected override void SubscribeButtons()
        {
            base.SubscribeButtons();
            _nextSpriteButton.onClick.AddListener(OnNextSpriteButtonClick);
            _previousSpriteButton.onClick.AddListener(OnPreviousSpriteButtonClick);
        }

        protected override void UnsubscribeButtons()
        {
            base.UnsubscribeButtons();
            _nextSpriteButton.onClick.RemoveListener(OnNextSpriteButtonClick);
            _previousSpriteButton.onClick.RemoveListener(OnPreviousSpriteButtonClick);
        }

        private void OnDataLoaded()
        {
            UpdateCurrentSpriteView();
        }

        private void OnNextSpriteButtonClick()
        {
            _spritesController.ChangeToNextSprite();
            UpdateCurrentSpriteView();
        }
        
        private void OnPreviousSpriteButtonClick()
        {
            _spritesController.ChangeToPreviousSprite();
            UpdateCurrentSpriteView();
        }

        private void UpdateCurrentSpriteView()
        {
            _currentSpriteView.sprite = _spritesController.GetCurrentSprite();
        }
    }
}