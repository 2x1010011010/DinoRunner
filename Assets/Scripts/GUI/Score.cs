using Dinosaur;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace GUI
{
  public class Score : MonoBehaviour
  {
    [SerializeField] private Player _player;

    private int _lastRecordScore;
    private int _currentScore;
    public event UnityAction SpeedChanged;

    public int Record => _lastRecordScore;
    public int CurrentScore => _currentScore;

    public void SetRecord(int score) => 
      _lastRecordScore = score;
    
    public void Clear() => 
      _currentScore = 0;

    private void OnEnable() => 
      _player.ScoreChanged += OnScoreChanged;

    private void OnDisable() => 
      _player.ScoreChanged -= OnScoreChanged;

    private void OnScoreChanged(int score) => 
      _currentScore = score;
  }
}