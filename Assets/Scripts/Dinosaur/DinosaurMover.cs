using UnityEngine;
using UnityEngine.EventSystems;

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
      if (_rigidbody.linearVelocity.y != 0)
      {
        _animation.PlayJumpAnimation();
      }
      else
      {
        _animation.PlayRunAnimation();
      }

      if (Mathf.Approximately(Time.timeScale, 0))
        return;

      if (Input.GetKeyDown(KeyCode.Space))
      {
        Jump();
        return;
      }

      if (Input.GetMouseButtonDown(0) && !IsPointerOverUI())
      {
        Jump();
      }
    }

    private void Jump()
    {
      if (_rigidbody.linearVelocity.y != 0)
        return;
      
      ResetDinosaurMove();
      _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
      _jumpSoundEffect.Play();
    }

    public void ResetDinosaurMove()
    {
      _rigidbody.linearVelocity = Vector2.zero;
    }

    private bool IsPointerOverUI()
    {
      if (EventSystem.current == null)
        return false;

      var pointerEventData = new PointerEventData(EventSystem.current)
      {
        position = Input.mousePosition
      };

      var results = new System.Collections.Generic.List<RaycastResult>();
      EventSystem.current.RaycastAll(pointerEventData, results);

      return results.Count > 0;
    }
  }
}