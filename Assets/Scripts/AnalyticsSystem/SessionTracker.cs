using UnityEngine;

namespace AnalyticsSystem
{
  public class SessionTracker : MonoBehaviour
  {
    private float _sessionStartTime;

    private void Awake()
    {
      AnalyticsMessageSender.Initialize();
      _sessionStartTime = Time.realtimeSinceStartup;
    }

    private void OnApplicationPause(bool pauseStatus)
    {
      if (pauseStatus)
        EndSession();
      else
        _sessionStartTime = Time.realtimeSinceStartup;
    }

    private void OnApplicationQuit()
    {
      EndSession();
    }

    private void EndSession()
    {
      float sessionLength = Time.realtimeSinceStartup - _sessionStartTime;
      AnalyticsMessageSender.LogSessionLength(sessionLength);
    }
  }
}