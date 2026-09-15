using System;
using GUI.Screens;
using UnityEngine;

namespace GUI
{
  public class GameUIObserver : MonoBehaviour
  {
    [Header("Game UI Observer")]
    [Header("SCREENS")]
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private PauseScreen _pauseScreen;

    [Header("SCREENS OBJECTS")]
    [SerializeField] private GameObject _gameScreenObject;
    [SerializeField] private GameObject _endScreenObject;
    [SerializeField] private GameObject _startScreenObject;
    [SerializeField] private GameObject _settingsScreenObject;
    [SerializeField] private GameObject _pauseScreenObject;

    public event Action StartGameRequested;
    public event Action SettingsOpenRequested;
    public event Action SettingsCloseRequested;
    public event Action RestartGameRequested;
    public event Action PauseRequested;
    public event Action ResumeRequested;

    public void OpenStartScreen()
    {
      _startScreenObject.SetActive(true);
      _startScreen.Open();

      _startScreen.OnStart += OnStartRequested;
      _startScreen.OnSettingsShow += OnSettingsOpenRequested;
    }

    public void CloseStartScreen()
    {
      _startScreen.OnStart -= OnStartRequested;
      _startScreen.OnSettingsShow -= OnSettingsOpenRequested;

      _startScreen.Close();
      _startScreenObject.SetActive(false);
    }

    public void OpenSettingsScreen()
    {
      _settingsScreenObject.SetActive(true);
      _settingsScreen.Open();

      _settingsScreen.OnSettingsClose += OnSettingsCloseRequested;
    }

    public void CloseSettingsScreen()
    {
      _settingsScreen.OnSettingsClose -= OnSettingsCloseRequested;

      _settingsScreen.Close();
      _settingsScreenObject.SetActive(false);
    }

    public void OpenEndScreen()
    {
      _endScreenObject.SetActive(true);
      _endScreen.Open();
      _endScreen.OnRestart += OnRestartRequested;
    }

    public void CloseEndScreen()
    {
      _endScreen.OnRestart -= OnRestartRequested;

      _endScreen.Close();
      _endScreenObject.SetActive(false);
    }

    public void SetScore(int score)
    {
      _gameScreen.SetScore(score);
    }
    
    public void OpenGameScreen()
    {
      _gameScreenObject.SetActive(true);
      _gameScreen.Open();
      _gameScreen.OnPauseRequested += OnPauseRequested;
    }

    public void CloseGameScreen()
    {
      _gameScreen.OnPauseRequested -= OnPauseRequested;

      _gameScreen.Close();
      _gameScreenObject.SetActive(false);
    }

    public void OpenPauseScreen()
    {
      _pauseScreenObject.SetActive(true);
      _pauseScreen.Open();

      _pauseScreen.OnResume += OnResumeRequested;
      _pauseScreen.OnSettingsShow += OnSettingsOpenRequested;
    }

    public void ClosePauseScreen()
    {
      _pauseScreen.OnResume -= OnResumeRequested;
      _pauseScreen.OnSettingsShow -= OnSettingsOpenRequested;

      _pauseScreen.Close();
      _pauseScreenObject.SetActive(false);
    }

    public void CloseAllScreens()
    {
      CloseStartScreen();
      CloseSettingsScreen();
      CloseGameScreen();
      CloseEndScreen();
      ClosePauseScreen();
    }

    private void OnStartRequested() =>
      StartGameRequested?.Invoke();

    private void OnSettingsOpenRequested() =>
      SettingsOpenRequested?.Invoke();

    private void OnSettingsCloseRequested() =>
      SettingsCloseRequested?.Invoke();

    private void OnRestartRequested() =>
      RestartGameRequested?.Invoke();
    
    private void OnPauseRequested() =>
      PauseRequested?.Invoke();

    private void OnResumeRequested() =>
      ResumeRequested?.Invoke();
  }
}
