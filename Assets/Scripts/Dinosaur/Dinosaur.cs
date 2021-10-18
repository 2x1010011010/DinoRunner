using UnityEngine;
using UnityEngine.Events;

public class Dinosaur : MonoBehaviour
{
    private int _score;

    public int Score => _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
