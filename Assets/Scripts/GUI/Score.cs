using TMPro;
using UnityEngine;

namespace GUI
{
  public class Score : MonoBehaviour
  {
    private int _lastRecordScore;
    private int _currentScore;

    public int Record => _lastRecordScore;
    public int CurrentScore => _currentScore;

    private void Awake()
    {
      _lastRecordScore = PlayerPrefs.GetInt("Record", 0);
    }

    public void Increment()
    {
      _currentScore++;
    }

    public void Clear()
    {
      _currentScore = 0;
    }

    public void SetRecord()
    {
      if (_currentScore <= _lastRecordScore) return;

      _lastRecordScore = _currentScore;
      PlayerPrefs.SetInt("Record", _lastRecordScore);
      PlayerPrefs.Save();
    }
  }
}