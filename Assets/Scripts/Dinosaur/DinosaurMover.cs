using GUI;
using UnityEngine;

namespace Dinosaur
{
  [RequireComponent(typeof(Rigidbody2D))]
  public class DinosaurMover : MonoBehaviour
  {
    [SerializeField] private float _jumpForce;
    [SerializeField] private AnimationSwitcher _animation;
    [SerializeField] private AudioSource _jumpSoundEffect;

    private Rigidbody2D _rigidbody;
    
    private void Start()
    {
      _rigidbody = GetComponent<Rigidbody2D>();
      _animation.PlayRunAnimation();
      ResetDinosaurMove();
    }

    private void Update()
    {
      if (Mathf.Approximately(Time.timeScale, 1) && _rigidbody.linearVelocity.y == 0)
      {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
          ResetDinosaurMove();
          _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
          _jumpSoundEffect.Play();
        }
      }

      if (_rigidbody.linearVelocity.y != 0)
      {
        _animation.PlayJumpAnimation();
      }
      else
      {
        _animation.PlayRunAnimation();
      }
    }

    public void ResetDinosaurMove()
    {
      _rigidbody.linearVelocity = Vector2.zero;
    }
  }
}