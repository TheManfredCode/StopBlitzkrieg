using System;
using UnityEngine;

public class ScoreHandler
{
    private int _enemiesDestroyed;
    private int _score;
    private ScoreCoeficientLoader _scoreCoeficientLoader;
    private const int HARD_MODE_SCORE = 5;
    private const string TOP_SCORE_KEY = "topScore";

    public ScoreHandler(ScoreCoeficientLoader scoreCoeficientLoader)
    {
        _scoreCoeficientLoader = scoreCoeficientLoader;
        _scoreCoeficientLoader.CoeficientLoaded += UpdateCoeficientScore;
    }
    
    public event Action HardModeScoreReached;
    public event Action<int> ScoreUpdated;
    public event Action<int> TopScoreUpdated;
    public event Action<int> ScoreCoeficientUpdated;

    public void ResetScore()
    {
        if (_score > GetTopScore())
            SaveNewRecord(_score);
        
        _enemiesDestroyed = 0;
        _score = 0;
        
        ScoreUpdated?.Invoke(_score);
    }
    
    public void IncreaseScore()
    {
        _enemiesDestroyed++;
        _score += ScoreCoefficient;
            
        if(_enemiesDestroyed >= HARD_MODE_SCORE)
            HardModeScoreReached?.Invoke();
        
        ScoreUpdated?.Invoke(_score);
    }

    public float GetScore()
    {
        return _score;
    }
    
    public int GetTopScore()
    {
        int result = 0;

        if (PlayerPrefs.HasKey(TOP_SCORE_KEY))
        {
            result = PlayerPrefs.GetInt(TOP_SCORE_KEY);
        }

        return result;
    }

    private void UpdateCoeficientScore(int value)
    {
        ScoreCoeficientUpdated?.Invoke(value);
    }
    
    public int ScoreCoefficient => _scoreCoeficientLoader.Coeficient;

    private void SaveNewRecord(int value)
    {
        PlayerPrefs.SetInt(TOP_SCORE_KEY, value);
        PlayerPrefs.Save();
        
        TopScoreUpdated?.Invoke(value);
    }
}