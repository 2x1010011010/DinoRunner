using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EndScreen : Screen
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreText;
    public event UnityAction RestartButtonClick;
}
