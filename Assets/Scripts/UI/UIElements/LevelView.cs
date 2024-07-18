using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace UI.UIElements
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _previousLevelButton;
        [SerializeField] private TMP_Text _currentLevel;

        private LevelScenesController _scenesController;

        [Inject]
        private void Construct(LevelScenesController scenesController)
        {
            _scenesController = scenesController;
            AfterConstructed();
        }

        private void AfterConstructed()
        {
            _scenesController.SceneKeyUpdateEvent += OnSceneKeyUpdate;
        }

        private void OnEnable()
        {
            _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
            _previousLevelButton.onClick.AddListener(OnPreviousLevelButtonClick);
        }

        private void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
            _previousLevelButton.onClick.RemoveListener(OnPreviousLevelButtonClick);
        }

        private void OnNextLevelButtonClick()
        {
            _scenesController.ChangeToNextLevel();
        }
        
        private void OnPreviousLevelButtonClick()
        {
            _scenesController.ChangeToPreviousLevel();
        }

        private void OnSceneKeyUpdate(int value)
        {
            _currentLevel.text = (value + 1).ToString();
        }
    }
}