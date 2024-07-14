using TMPro;
using UnityEngine;
using Zenject;

namespace UI.UIElements
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private TMP_Text _topScoreLabel;
        [SerializeField] private TMP_Text _scoreCoeficientLabel;

        private ScoreHandler _scoreHandler;
        
        [Inject]
        private void Construct(ScoreHandler scoreHandler)
        {
            _scoreHandler = scoreHandler;
            
            AfterConstructed();
        }

        private void AfterConstructed()
        {
            _scoreHandler.ScoreUpdated += UpdateScoreLabel;
            _scoreHandler.TopScoreUpdated += UpdateTopScoreLabel;
            _scoreHandler.ScoreCoeficientUpdated += UpdateScoreCoeficientLabel;
            
            UpdateScoreCoeficientLabel(_scoreHandler.ScoreCoefficient);
            UpdateTopScoreLabel(_scoreHandler.GetTopScore());
        }
        
        public void Init(ScoreHandler scoreHandler)
        {
            scoreHandler.ScoreUpdated += UpdateScoreLabel;
            scoreHandler.TopScoreUpdated += UpdateTopScoreLabel;
            scoreHandler.ScoreCoeficientUpdated += UpdateScoreCoeficientLabel;
            
            UpdateScoreCoeficientLabel(scoreHandler.ScoreCoefficient);
            UpdateTopScoreLabel(scoreHandler.GetTopScore());
        }

        private void UpdateScoreLabel(int value)
        {
            _scoreLabel.text = value.ToString();
        }
        
        private void UpdateTopScoreLabel(int value)
        {
            _topScoreLabel.text = value.ToString();
        }
        
        private void UpdateScoreCoeficientLabel(int value)
        {
            _scoreCoeficientLabel.text = value.ToString();
        }
    }
}