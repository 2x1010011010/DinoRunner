using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    private void Start()
    {
        PlayRunAnimation();
    }

    public void PlayRunAnimation()
    {
        _animator.StopPlayback();
        _animator.Play("Run", 0);
    }

    public void PlayJumpAnimation()
    {
        _animator.StopPlayback();
        _animator.Play("Jump", 0);
    }

    public void PlayDieAnimation()
    {
        _animator.StopPlayback();
        _animator.Play("Die", 0);
    }
}
