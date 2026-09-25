using System;
using System.Collections.Generic;
using AdvertisingSystem;
using Firebase;
using Firebase.Analytics;
using JetBrains.Annotations;
using UnityEngine;

namespace AnalyticsSystem
{
  public static class AnalyticsMessageSender
  {
    static DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    private static bool firebaseInitialized = false;
    private static string logText = "";
    private const int kMaxLogSize = 16382;
    private static Advertising _advertising;
    private static int _levelNumber;
    private static int _levelCount;

    public static void Initialize()
    {
      try
      {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
          var dependencyStatus = task.Result;
          if (dependencyStatus == DependencyStatus.Available)
          {
            InitializeFirebase();
          }
          else
          {
            Debug.LogError(String.Format(
              "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
          }
        });
      }
      catch (Exception e)
      {
        Debug.Log("Exception: " + e);
      }
    }

    private static void InitializeFirebase()
    {
      DebugLog("Enabling data collection.", true);
      FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

      DebugLog("Set user properties.", true);

      FirebaseAnalytics.SetUserProperty(
        FirebaseAnalytics.UserPropertySignUpMethod,
        "Google");

      FirebaseAnalytics.SetSessionTimeoutDuration(new TimeSpan(0, 30, 0));
      firebaseInitialized = true;
    }

    private static void DebugLog(string eventName, bool isLogActive)
    {
      if (isLogActive)
      {
        Debug.Log("FIREBASE SEND EVENT" + eventName);
        logText += eventName + "\n";

        while (logText.Length > kMaxLogSize)
        {
          int index = logText.IndexOf("\n");
          logText = logText.Substring(index + 1);
        }
      }
    }

    public static void SendAnalitycsData(string eventName, Dictionary<string, object> data, bool isLogActive)
    {
      List<Parameter> parameters = new List<Parameter>();

      foreach (var item in data)
      {
        if (item.Value is int)
        {
          parameters.Add(new Parameter(item.Key, (int)item.Value));
        }
        else if (item.Value is long)
        {
          parameters.Add(new Parameter(item.Key, (long)item.Value));
        }
        else if (item.Value is double)
        {
          parameters.Add(new Parameter(item.Key, (double)item.Value));
        }
        else if (item.Value is float)
        {
          parameters.Add(new Parameter(item.Key, (float)item.Value));
        }
        else if (item.Value is string)
        {
          parameters.Add(new Parameter(item.Key, (string)item.Value));
        }
      }

      FirebaseAnalytics.LogEvent(eventName, parameters.ToArray());

      if (isLogActive)
      {
        Debug.Log("FIREBASE SEND EVENT: " + eventName + "; PARAMS:");
        foreach (var item in data)
          Debug.Log(item.Key + " " + item.Value);
      }
    }

    public static void LevelStart([CanBeNull] string levelName, bool isLogActive)
    {
      if (_levelNumber != 0)
      {
        _levelNumber++;
      }
      else
      {
        _levelNumber = 1;
      }


      if (PlayerPrefs.HasKey("LevelCount"))
      {
        _levelCount = PlayerPrefs.GetInt("LevelCount");
        _levelCount++;
      }
      else
      {
        _levelCount = 1;
      }

      Dictionary<string, object> data = new Dictionary<string, object>
      {
        { "level_number", _levelNumber },
        { "level_name", levelName },
        { "level_count", _levelCount },
      };

      SendAnalitycsData("level_start", data, isLogActive);
      PlayerPrefs.SetInt("LevelCount", _levelCount);
      PlayerPrefs.SetString("LevelName", levelName);
    }

    public static void LevelEnd(bool isLogActive)
    {
      string levelName = PlayerPrefs.GetString("LevelName");
      Dictionary<string, object> data = new Dictionary<string, object>
      {
        { "level_number", _levelNumber },
        { "level_name", levelName },
        { "level_count", _levelCount },
      };

      SendAnalitycsData("level_finish", data, isLogActive);
    }
    

    public static void VideoAdsAvailable(bool isLogActive)
    {
      Dictionary<string, object> data = new Dictionary<string, object>
      {
        { "ad_type", "interstitial" },
        { "placement", "ad_on_replay" },
        {
          "result",
          Application.internetReachability == NetworkReachability.NotReachable ? "not_available" : "success"
        },
        { "connection", Application.internetReachability == NetworkReachability.NotReachable ? 0 : 1 }
      };

      if (_advertising.IsInterstitialReady)
      {
          SendAnalitycsData("video_ads_available", data, isLogActive);
      }
    }

    public static void VideoAdsStarted(bool isLogActive)
    {
      Dictionary<string, object> data = new Dictionary<string, object>
      {
        { "ad_type", "interstitial" },
        { "placement", "ad_on_replay" },
        { "result", "started" },
        { "connection", Application.internetReachability == NetworkReachability.NotReachable ? 0 : 1 }
      };

      if (Application.internetReachability != NetworkReachability.NotReachable)
        SendAnalitycsData("video_ads_started", data, isLogActive);
    }

    public static void VideoAdsWatch(bool isLogActive)
    {
      Dictionary<string, object> data = new Dictionary<string, object>
      {
        { "ad_type", "interstitial" },
        { "placement", "ad_on_replay" },
        {
          "result",
          Application.internetReachability == NetworkReachability.NotReachable ? "not_available" : "watched"
        },
        { "connection", Application.internetReachability == NetworkReachability.NotReachable ? 0 : 1 }
      };

      if (Application.internetReachability != NetworkReachability.NotReachable)
        SendAnalitycsData("video_ads_watch", data, isLogActive);
    }
  }
}