using GUI.Screens;
using UnityEngine;
using UnityEngine.Serialization;

namespace GUI
{
  public class GameUIObserver : MonoBehaviour
  {
    [Header("Game UI Observer")]
    [Header("GAME SETUP")]
    [SerializeField] private Game _game;
    [Header("SCREENS")]
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    [Header("SCREENS OBJECTS")]
    [SerializeField] private GameObject _gameScreenObject;
    [SerializeField] private GameObject _endScreenObject;
    [SerializeField] private GameObject _startScreenObject;
    [SerializeField] private GameObject _settingsScreenObject;

    private void Awake()
    {
      _startScreenObject.SetActive(true);
      _startScreen.Open();
    }

    private void OpenStartScreen()
    {
      _startScreenObject.SetActive(true);
      _startScreen.Open();
      _startScreen.OnStart += StartGame;
      _startScreen.OnSettingsShow += ShowSettings;
    }

    private void StartGame()
    {
      
    }

    private void ShowSettings()
    {
      _startScreenObject.SetActive(false);
      _settingsScreenObject.SetActive(true);
      _settingsScreen.Open();
    }
  }
}