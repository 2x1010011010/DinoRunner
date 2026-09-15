using System;
using GUI.Buttons;
using TMPro;
using UnityEngine;

namespace GUI.Screens
{
  public class PauseScreen : Screen
  {
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _recordScoreText;
    [SerializeField] private BackButton _backButton;
    [SerializeField] private SettingsButton _settingsButton;

    public event Action OnResume;
    public event Action OnSettingsShow;

    public override void Open()
    {
      _scoreText.text = _score.CurrentScore.ToString();
      _recordScoreText.text = _score.Record.ToString();

      _backButton.OnBackButtonClick += BackButtonClick;
      _settingsButton.OnSettingsButtonClick += SettingsButtonClick;
    }

    public override void Close()
    {
      _backButton.OnBackButtonClick -= BackButtonClick;
      _settingsButton.OnSettingsButtonClick -= SettingsButtonClick;
    }

    private void BackButtonClick() =>
      OnResume?.Invoke();

    private void SettingsButtonClick() =>
      OnSettingsShow?.Invoke();
  }
}