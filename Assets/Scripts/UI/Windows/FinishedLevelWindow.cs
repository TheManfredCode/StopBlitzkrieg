using System;
using Ads;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class FinishedLevelWindow : BaseWindow
    {
        [SerializeField] private Button _playNextLevelButton;
        [SerializeField] private Button _adButton;
        [SerializeField] private TMP_Text _adRewardGainedLabel;

        private InterfaceController _interfaceController;
        private AdsHandler _adsHandler;
        private ScoreHandler _scoreHandler;
        
        [Inject]
        private void Construct(InterfaceController interfaceController, AdsHandler adsHandler, ScoreHandler scoreHandler)
        {
            _interfaceController = interfaceController;
            _adsHandler = adsHandler;
            _scoreHandler = scoreHandler;
        }

        protected override void OnEnabled()
        {
            _adButton.gameObject.SetActive(true);
            _adRewardGainedLabel.gameObject.SetActive(false);
        }

        protected override void SubscribeButtons()
        {
            base.SubscribeButtons();
            _playNextLevelButton.onClick.AddListener(OnPlayNextLevelButtonClick);
            _adButton.onClick.AddListener(OnAdButtonClick);
        }

        protected override void UnsubscribeButtons()
        {
            base.UnsubscribeButtons();
            _playNextLevelButton.onClick.RemoveListener(OnPlayNextLevelButtonClick);
            _adButton.onClick.RemoveListener(OnAdButtonClick);
        }

        private void OnPlayNextLevelButtonClick()
        {
            _interfaceController.OnStartGameClick();
            Close();
        }

        private void OnAdButtonClick()
        {
            _adsHandler.ShowRewardedAd(RewardedAdCallback);
        }

        private void RewardedAdCallback(bool isWatched)
        {
            if (isWatched)
            {
                _scoreHandler.TripleScore();
                _adButton.gameObject.SetActive(false);
                _adRewardGainedLabel.gameObject.SetActive(true);
            }
        }
    }
}