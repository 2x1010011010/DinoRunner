using System;
using GUI.Buttons;
using TMPro;
using UnityEngine;

namespace GUI.Screens
{
  public class GameScreen : Screen
  {
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private PauseButton _pauseButton;

    public event Action OnPauseRequested;

    public override void Open()
    {
      SetScore(0);
      _pauseButton.OnPauseClick += PauseButtonClick;
    }

    public void SetScore(int score)
    {
      _scoreText.text = score.ToString();
    }

    public override void Close()
    {
      _pauseButton.OnPauseClick -= PauseButtonClick;
    }

    private void PauseButtonClick() =>
      OnPauseRequested?.Invoke();
  }
}