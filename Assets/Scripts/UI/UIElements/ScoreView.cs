using TMPro;
using UnityEngine;

namespace UI.UIElements
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private TMP_Text _topScoreLabel;
        [SerializeField] private TMP_Text _scoreCoeficientLabel;

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