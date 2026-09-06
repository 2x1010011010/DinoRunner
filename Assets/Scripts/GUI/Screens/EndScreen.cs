using TMPro;
using UnityEngine;

namespace GUI.Screens
{
  public class EndScreen : Screen
  {
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _recordScoreText;

    public override void Open()
    {
      _scoreText.text = _score.CurrentScore.ToString();
      _recordScoreText.text = _score.Record.ToString();
    }

    public override void Close()
    {
    }
  }
}