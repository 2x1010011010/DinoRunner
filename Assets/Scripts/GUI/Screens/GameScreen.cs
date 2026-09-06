using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GUI.Screens
{
  public class GameScreen : Screen
  {
    [SerializeField] private TMP_Text _score;
    private Game _game;
    
    public void Init(Game game)
    {
      _game = game;
    }

    public override void Open()
    {
      _score.text = "0";
      
    }

    public override void Close()
    {
      throw new System.NotImplementedException();
    }
  }
}