using TMPro;
using UnityEngine;

namespace GUI.Screens
{
  public class GameScreen : Screen
  {
    [SerializeField] private TMP_Text _scoreText;

    public override void Open()
    {
      _scoreText.text = "0";
    }

    public override void Close()
    {
      
    }
  }
}