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
    [SerializeField] private TMP_Text _maxScore;
    [SerializeField] private int _speedChangeScore;

    private int _lastRecordScore;
    public event UnityAction SpeedChanged;
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
        
        if (score > _lastRecordScore)
        {
            _maxScore.text = score.ToString();
            _lastRecordScore = score;
        }

        if (score % _speedChangeScore == 0)
        {
            SpeedChanged?.Invoke();
        }
    }
}
