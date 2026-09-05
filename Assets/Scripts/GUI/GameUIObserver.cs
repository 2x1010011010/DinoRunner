using UnityEngine;

namespace GUI
{
  public class GameUIObserver : MonoBehaviour
  {
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private StartScreen _startScreen; 
    [SerializeField] private OptionsScreen _optionsScreen;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
    
  }
}