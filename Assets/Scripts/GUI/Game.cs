using BackgroundParallax;
using Cacti;
using Dinosaur;
using UnityEngine;

namespace GUI
{
  public class Game : MonoBehaviour
  {
    [SerializeField] private Player _player;
    [SerializeField] private GameUIObserver _gameUIObserver;
    [SerializeField] private Score _score;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ParallaxObserver _parallax;

    private void Awake()
    {
      Time.timeScale = 0f;
      _gameUIObserver.OpenStartScreen();
    }

    private void OnEnable()
    {
      
    }

    private void OnDisable()
    {
      
    }

    private void StartGame()
    {
      
    }

    private void EndGame()
    {
      
    }

    private void ChangeScore()
    {
      
    }

    private void ChangeSpeed()
    {
      
    }

    private void RestartGame()
    {
      
    }
  }
}