using Cacti;
using UnityEngine;

namespace Dinosaur
{
    [RequireComponent(typeof(global::Dinosaur.Dinosaur))]
    public class DinosaurCollisionHandler : MonoBehaviour
    {
        private global::Dinosaur.Dinosaur _dinosaur;

        private void Start()
        {
            _dinosaur = GetComponent<global::Dinosaur.Dinosaur>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ScoreZone scoreZone))
            {
                _dinosaur.IncreaseScore();
                scoreZone.Disable();
            }
            else
            {
                _dinosaur.Die();
            }
        }
    }
}
