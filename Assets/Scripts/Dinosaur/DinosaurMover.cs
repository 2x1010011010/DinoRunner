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
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _speedIncrease;
    [SerializeField] private Score _score;

    private Rigidbody2D _rigidbody;
    private float _speed;

    private void OnEnable()
    {
      _score.SpeedChanged += OnSpeedChanged;
    }

    private void OnDisable()
    {
      _score.SpeedChanged -= OnSpeedChanged;
    }

    private void Start()
    {
      _speed = _startSpeed;
      _rigidbody = GetComponent<Rigidbody2D>();
      _animation.PlayRunAnimation();
      ResetDinosaurMove();
    }

    private void Update()
    {
      if (Time.timeScale == 1 && _rigidbody.linearVelocity.y == 0)
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

    public void ResetSpeed()
    {
      _speed = _startSpeed;
    }

    public void OnSpeedChanged()
    {
      _speed += _speedIncrease;
    }
  }
}