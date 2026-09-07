using GUI.Screens;
using UnityEngine;

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

    private void Awake() => 
      OpenStartScreen();

    private void OpenStartScreen()
    {
      _startScreenObject.SetActive(true);
      _startScreen.Open();
      _startScreen.OnStart += StartGame;
      _startScreen.OnSettingsShow += OpenSettingsScreen;
    }

    private void CloseStartScreen()
    {
      _startScreen.Close();
      _startScreen.OnStart -= CloseStartScreen;
      _startScreen.OnSettingsShow -= OpenSettingsScreen;
      _startScreenObject.SetActive(false);
    }

    private void StartGame()
    {
      CloseStartScreen();
      OpenGameScreen();
    }

    private void OpenSettingsScreen()
    {
      CloseStartScreen();
      _settingsScreenObject.SetActive(true);
      _settingsScreen.Open();
      _settingsScreen.OnSettingsClose += CloseSettingsScreen;
    }

    private void CloseSettingsScreen()
    {
      _settingsScreen.OnSettingsClose -= CloseSettingsScreen;
      _settingsScreenObject.SetActive(false);
      OpenStartScreen();
    }

    private void OpenGameScreen()
    {
      _gameScreenObject.SetActive(true);
      _gameScreen.Open();
    }

    private void CloseGameScreen()
    {
      _gameScreen.Close();
      _gameScreenObject.SetActive(false);
    }

    private void OpenGameOverScreen()
    {
      _gameScreenObject.SetActive(true);
      _gameScreen.Open();
    }

    private void CloseGameOverScreen()
    {
      _gameScreen.Close();
      _gameScreenObject.SetActive(false);
    }
  }
}