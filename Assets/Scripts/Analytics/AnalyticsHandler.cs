using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsHandler
{
    public void LogLevelSuccess(int level, float score)
    {
        Analytics.CustomEvent(AnalyticsEventName.LevelSuccess, new Dictionary<string, object>()
        {
            {"Level", level},
            {"ReachedScore", score}
        });
        Debug.Log($"[Analytics] Log {AnalyticsEventName.LevelSuccess}. Level {level}, ReachedScore {score}");
    }
    
    public void LogLevelFail(int level, float score)
    {
        Analytics.CustomEvent(AnalyticsEventName.LevelFail, new Dictionary<string, object>()
        {
            {"Level", level},
            {"ReachedScore", score}
        });
        Debug.Log($"[Analytics] Log {AnalyticsEventName.LevelFail}. Level {level}, ReachedScore {score}");
    }
    
    public void LogNewRecord(float score)
    {
        Analytics.CustomEvent(AnalyticsEventName.NewRecord, new Dictionary<string, object>()
        {
            {"RecordScore", score}
        });
        Debug.Log($"[Analytics] Log {AnalyticsEventName.NewRecord}. RecordScore {score}");
    }
    
    public void LogRewardedAdWatchedSuccess()
    {
        Analytics.CustomEvent(AnalyticsEventName.RewardedAdWatchedSuccess);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.RewardedAdWatchedSuccess}.");
    }
    
    public void LogRewardedAdWatchedFail()
    {
        Analytics.CustomEvent(AnalyticsEventName.RewardedAdWatchedFail);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.RewardedAdWatchedFail}.");
    }
    
    public void LogRewardedAdClicked()
    {
        Analytics.CustomEvent(AnalyticsEventName.RewardedAdClicked);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.RewardedAdClicked}.");
    }
    
    public void LogInterstitialAdClicked()
    {
        Analytics.CustomEvent(AnalyticsEventName.InterstitialAdClicked);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.InterstitialAdClicked}.");
    }
    
    public void LogBannerAdClicked()
    {
        Analytics.CustomEvent(AnalyticsEventName.BannerAdClicked);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.BannerAdClicked}.");
    }
}