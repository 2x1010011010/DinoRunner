using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Dinosaur _dinosaur;
    [SerializeField] private DinosaurMover _dinosaurMover;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private BackgroundChanger _backgroundChanger;
    [SerializeField] private TMP_Text _maxScore;
    [SerializeField] private int _backChangeScore;

    private int _lastRecordScore;
    private int _currentScore;
    public event UnityAction SpeedChanged;

    public int Record => _lastRecordScore;
    public int CurrentScore => _currentScore;
    
    private void OnEnable()
    {
        _dinosaur.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _dinosaur.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
        _currentScore = score;
        
        if (score > _lastRecordScore)
        {
            _maxScore.text = score.ToString();
            _lastRecordScore = score;
        }

        if (score % _backChangeScore == 0)
        {
           _backgroundChanger.ChangeBackground();
        }
    }
}
