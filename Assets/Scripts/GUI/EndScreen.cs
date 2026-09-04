using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EndScreen : Screen
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreText;
    public event UnityAction RestartButtonClick;
    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _scoreText.text = _score.CurrentScore.ToString();
        Button.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
