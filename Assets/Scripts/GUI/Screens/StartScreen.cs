using System;
using GUI.Buttons;
using UnityEngine;

namespace GUI.Screens
{
  public class StartScreen : Screen
  {
    public event Action OnStart;
    public event Action OnSettingsShow;

    [SerializeField] private StartButton _startButton;
    [SerializeField] private SettingsButton _settingsButton;

    public override void Open()
    {
      _startButton.OnStartButtonClicked += StartGame;
      _settingsButton.OnSettingsButtonClick += ShowSettings;
    }

    public override void Close()
    {
      _startButton.OnStartButtonClicked -= StartGame;
      _settingsButton.OnSettingsButtonClick -= ShowSettings;
    }

    private void StartGame() =>
      OnStart?.Invoke();

    private void ShowSettings() =>
      OnSettingsShow?.Invoke();
  }
}