using Firebase.Analytics;
using UnityEngine;

public class AnalyticsHandler
{
    public void LogLevelSuccess(int level, float score)
    {
        FirebaseAnalytics.LogEvent(AnalyticsEventName.LevelSuccess, new Parameter[]
        {
            new Parameter("Level", level),
            new Parameter("ReachedScore", score)
        });
        
        Debug.Log($"[Analytics] Log {AnalyticsEventName.LevelSuccess}. Level {level}, ReachedScore {score}");
    }
    
    public void LogLevelFail(int level, float score)
    {
        FirebaseAnalytics.LogEvent(AnalyticsEventName.LevelFail, new Parameter[]
        {
            new Parameter("Level", level),
            new Parameter("ReachedScore", score)
        });
        
        Debug.Log($"[Analytics] Log {AnalyticsEventName.LevelFail}. Level {level}, ReachedScore {score}");
    }
    
    public void LogNewRecord(float score)
    {
        FirebaseAnalytics.LogEvent(AnalyticsEventName.NewRecord, new Parameter[]
        {
            new Parameter("RecordScore", score),
        });
        
        Debug.Log($"[Analytics] Log {AnalyticsEventName.NewRecord}. RecordScore {score}");
    }
    
    public void LogRewardedAdWatchedSuccess()
    {
        FirebaseAnalytics.LogEvent(AnalyticsEventName.RewardedAdWatchedSuccess);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.RewardedAdWatchedSuccess}.");
    }
    
    public void LogRewardedAdWatchedFail()
    {
        FirebaseAnalytics.LogEvent(AnalyticsEventName.RewardedAdWatchedFail);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.RewardedAdWatchedFail}.");
    }
    
    public void LogRewardedAdClicked()
    {
        FirebaseAnalytics.LogEvent(AnalyticsEventName.RewardedAdClicked);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.RewardedAdClicked}.");
    }
    
    public void LogInterstitialAdClicked()
    {
        FirebaseAnalytics.LogEvent(AnalyticsEventName.InterstitialAdClicked);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.InterstitialAdClicked}.");
    }
    
    public void LogBannerAdClicked()
    {
        FirebaseAnalytics.LogEvent(AnalyticsEventName.BannerAdClicked);
        Debug.Log($"[Analytics] Log {AnalyticsEventName.BannerAdClicked}.");
    }
}