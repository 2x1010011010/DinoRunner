using System;
using System.Collections.Generic;
using UnityEngine;

namespace BackgroundParallax
{
  [Serializable]
  public class ParallaxLayer
  {
    [Header("SPRITES SETUP")] 
    [SerializeField] private List<SpriteRenderer> _spriteRenderers;
    [Space(15)]
    [SerializeField] private int _sortingOrder;
    
    [Header("MOVING SETUP")] 
    [SerializeField] private float _speed;
    [SerializeField] private float _borderCoordinate;
    [SerializeField] private float _shiftDistance;

    public float LayerSpeed => _speed;
    public List<SpriteRenderer> SpriteObjects => _spriteRenderers;

    public void ChangeSpeed(float speed) =>
      _speed = speed;

    public void ChangeSprites()
    {
      Debug.Log("Changing sprite position");
      var position = _spriteRenderers[0].transform.position;
      _spriteRenderers[0].transform.position = new Vector3(_shiftDistance, position.y, 0);

      var tempSpriteRenderer = _spriteRenderers[0];
      for (int i = 0; i < _spriteRenderers.Count - 1; i++)
      {
        _spriteRenderers[i] = _spriteRenderers[i + 1];
      }

      _spriteRenderers[^1] = tempSpriteRenderer;
    }

    public ParallaxLayer CheckLayers()
    {
      foreach(var spriteRenderer in _spriteRenderers)
        if (spriteRenderer.transform.position.x < _borderCoordinate)
          return this;

      return null;
    }

    public void Move()
    {
      foreach(var spriteRenderer in _spriteRenderers)
        spriteRenderer.transform.position += Vector3.left * (_speed * Time.deltaTime);
    }
  }
}