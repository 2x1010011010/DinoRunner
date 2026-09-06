using Cacti;
using UnityEngine;

namespace Dinosaur
{
    [RequireComponent(typeof(global::Dinosaur.Player))]
    public class DinosaurCollisionHandler : MonoBehaviour
    {
        private global::Dinosaur.Player _player;

        private void Start()
        {
            _player = GetComponent<global::Dinosaur.Player>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ScoreZone scoreZone))
            {
                _player.IncreaseScore();
                scoreZone.Disable();
            }
            else
            {
                _player.Die();
            }
        }
    }
}
