using System;
using UnityEngine;

namespace Cacti
{
  public class CactusMover : MonoBehaviour
  {
    private float _speed;
    
    public void SetSpeed(float speed) => 
      _speed = speed;

    private void Update()
    {
      if (!gameObject.activeSelf) return;
      
      transform.position -= transform.right * (_speed * Time.deltaTime);
    }
  }
}