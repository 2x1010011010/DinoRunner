using System;
using System.Collections.Generic;
using Firebase;
using Firebase.Analytics;
using UnityEngine;

namespace AnalyticsSystem
{
  public static class AnalyticsMessageSender
  {
    private const string _firstOpenKey = "HasOpenedBefore";

    private static bool _firebaseInitialized;

    public static void Initialize()
    {
      try
      {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
          if (task.Result == DependencyStatus.Available)
            InitializeFirebase();
          else
            Debug.LogError($"Could not resolve all Firebase dependencies: {task.Result}");
        });
      }
      catch (Exception e)
      {
        Debug.LogError("Firebase initialization exception: " + e);
      }
    }

    private static void InitializeFirebase()
    {
      FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
      _firebaseInitialized = true;

      LogFirstOpenIfNeeded();
    }

    private static void LogFirstOpenIfNeeded()
    {
      if (PlayerPrefs.GetInt(_firstOpenKey, 0) == 1) return;

      SendEvent("first_open", null);

      PlayerPrefs.SetInt(_firstOpenKey, 1);
      PlayerPrefs.Save();
    }

    public static void LogSessionLength(float seconds)
    {
      SendEvent("session_length", new Dictionary<string, object>
      {
        { "length_seconds", seconds }
      });
    }

    public static void LogInterstitialShown(string adUnitId)
    {
      SendEvent("interstitial_shown", new Dictionary<string, object>
      {
        { "ad_unit_id", adUnitId }
      });
    }

    private static void SendEvent(string eventName, Dictionary<string, object> data)
    {
      if (!_firebaseInitialized) return;

      if (data == null)
      {
        FirebaseAnalytics.LogEvent(eventName);
        return;
      }

      var parameters = new List<Parameter>();
      foreach (var item in data)
      {
        switch (item.Value)
        {
          case int i: parameters.Add(new Parameter(item.Key, i)); break;
          case long l: parameters.Add(new Parameter(item.Key, l)); break;
          case double d: parameters.Add(new Parameter(item.Key, d)); break;
          case float f: parameters.Add(new Parameter(item.Key, f)); break;
          case string s: parameters.Add(new Parameter(item.Key, s)); break;
        }
      }

      FirebaseAnalytics.LogEvent(eventName, parameters.ToArray());
    }
  }
}