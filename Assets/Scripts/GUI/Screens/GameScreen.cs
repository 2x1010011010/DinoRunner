using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace GUI.Screens
{
  public class GameScreen : Screen
  {
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Score _score;
    private Game _game;
    
    public void Init(Game game)
    {
      _game = game;
    }

    public override void Open()
    {
      _scoreText.text = "0";
      
    }

    public override void Close()
    {
      
    }
  }
}