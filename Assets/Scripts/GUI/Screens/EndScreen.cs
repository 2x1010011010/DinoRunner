using System;
using GUI.Buttons;
using TMPro;
using UnityEngine;

namespace GUI.Screens
{
  public class EndScreen : Screen
  {
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _recordScoreText;
    [SerializeField] private RestartButton _restartButton;

    public event Action OnRestart;

    public override void Open()
    {
      _scoreText.text = _score.CurrentScore.ToString();
      _recordScoreText.text = _score.Record.ToString();

      if (_restartButton == null)
        _restartButton = GetComponentInChildren<RestartButton>(true);

      if (_restartButton != null)
        _restartButton.OnRestartButtonClick += RestartButtonClick;
    }

    public override void Close()
    {
      if (_restartButton != null)
        _restartButton.OnRestartButtonClick -= RestartButtonClick;
    }

    private void RestartButtonClick() =>
      OnRestart?.Invoke();
  }
}