using System;
using BackgroundParallax;
using Cacti;
using Dinosaur;
using UnityEngine;

namespace GUI
{
  public class Game : MonoBehaviour
  {
    [Header("GAME SETUP")]
    [SerializeField] private Player _player;
    [SerializeField] private GameUIObserver _gameUIObserver;
    [SerializeField] private Score _score;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ParallaxObserver _parallax;

    [Header("SPEED SETUP")]
    [SerializeField] private float _startSpeed = 5f;
    [SerializeField] private float _speedDelta = 1f;
    [SerializeField] private int _scoreForSpeedIncrease = 50;

    private float _currentSpeed;
    private bool _isGameRunning;

    private void Awake()
    {
      _currentSpeed = _startSpeed;
      ApplySpeed();

      Time.timeScale = 0f;
      _gameUIObserver.CloseAllScreens();
      _gameUIObserver.OpenStartScreen();
    }

    private void OnEnable()
    {
      _player.GameOver += EndGame;
      _player.ScoreChanged += ChangeScore;

      _gameUIObserver.StartGameRequested += StartGame;
      _gameUIObserver.SettingsOpenRequested += OpenSettings;
      _gameUIObserver.SettingsCloseRequested += CloseSettings;
      _gameUIObserver.RestartGameRequested += RestartGame;
    }

    private void OnDisable()
    {
      _player.GameOver -= EndGame;
      _player.ScoreChanged -= ChangeScore;

      _gameUIObserver.StartGameRequested -= StartGame;
      _gameUIObserver.SettingsOpenRequested -= OpenSettings;
      _gameUIObserver.SettingsCloseRequested -= CloseSettings;
      _gameUIObserver.RestartGameRequested -= RestartGame;
    }

    private void StartGame()
    {
      _isGameRunning = true;

      _score.Clear();
      _player.ResetPlayer();
      _spawner.ResetPool();
      _spawner.ResetSpawner();

      _currentSpeed = _startSpeed;
      ApplySpeed();

      _gameUIObserver.CloseAllScreens();
      _gameUIObserver.OpenGameScreen();
      _gameUIObserver.SetScore(0);

      Time.timeScale = 1f;
    }

    private void EndGame()
    {
      if (!_isGameRunning) return;

      _isGameRunning = false;
      Time.timeScale = 0f;

      _score.SetRecord();

      _gameUIObserver.CloseAllScreens();
      _gameUIObserver.OpenEndScreen();
    }

    private void ChangeScore()
    {
      if (!_isGameRunning) return;

      _score.Increment();
      _gameUIObserver.SetScore(_score.CurrentScore);

      if (_score.CurrentScore > 0 &&
          _score.CurrentScore % _scoreForSpeedIncrease == 0)
      {
        ChangeSpeed();
      }
    }

    private void ChangeSpeed()
    {
      _currentSpeed += _speedDelta;
      ApplySpeed();
    }

    private void ApplySpeed()
    {
      _spawner.SetSpeed(_currentSpeed);
      _parallax.ChangeSpeed(_currentSpeed);
    }

    private void OpenSettings()
    {
      Time.timeScale = 0f;

      _gameUIObserver.CloseAllScreens();
      _gameUIObserver.OpenSettingsScreen();
    }

    private void CloseSettings()
    {
      _gameUIObserver.CloseAllScreens();
      _gameUIObserver.OpenStartScreen();
    }

    private void RestartGame()
    {
      StartGame();
    }
  }
}
