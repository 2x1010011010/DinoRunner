using TMPro;
using UnityEngine;

namespace GUI.Screens
{
  public class GameScreen : Screen
  {
    [SerializeField] private TMP_Text _scoreText;

    public override void Open()
    {
      SetScore(0);
    }

    public void SetScore(int score)
    {
      _scoreText.text = score.ToString();
    }

    public override void Close()
    {
    }
  }
}