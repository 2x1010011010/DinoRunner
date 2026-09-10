using UnityEngine;
using UnityEngine.Events;

namespace Dinosaur
{
    public class Player : MonoBehaviour
    {
        public event UnityAction GameOver;
        public event UnityAction ScoreChanged;

        public void IncreaseScore()
        {
            ScoreChanged?.Invoke();
        }

        public void ResetPlayer()
        {
            ScoreChanged?.Invoke();
        }

        public void Die()
        {
            GameOver?.Invoke();
        }
    }
}
