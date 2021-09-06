using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Dinosaur _dinosaur;
    [SerializeField] private DinosaurMover _dinosaurMover;
    [SerializeField] private GroundMover _groundMover;
    [SerializeField] private CactiGenerator _cactiGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private GameScreen _gameScreen;
   
 
    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _endScreen.RestartButtonClick += OnRestartButtonClick;
        _gameScreen.PauseButtonClick += OnPauseButtonClick;
        _dinosaur.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _endScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameScreen.PauseButtonClick -= OnPauseButtonClick;
        _dinosaur.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _endScreen.Close();
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _gameScreen.Open();
        StartGame(false);
    }



    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        _gameScreen.Open();
        _cactiGenerator.ResetPool();
        _dinosaurMover.ResetSpeed();
        StartGame(true);
    }

    private void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        _gameScreen.Close();
        _startScreen.Open();
    }

    private void StartGame(bool isRestart)
    {
        _dinosaurMover.ResetDinosaurMove();
        Time.timeScale = 1;
        if (isRestart)
        {
            _dinosaur.ResetPlayer();
        }
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameScreen.Close();
        _endScreen.Open();
    }
}
