using Cacti;
using UnityEngine;

namespace Dinosaur
{
  [RequireComponent(typeof(Player))]
  public class DinosaurCollisionHandler : MonoBehaviour
  {
    private Player _player;

    private void Start()
    {
      _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.TryGetComponent(out ScoreZone scoreZone))
      {
        _player.IncreaseScore();
      }
      else
      {
        _player.Die();
      }
    }
  }
}