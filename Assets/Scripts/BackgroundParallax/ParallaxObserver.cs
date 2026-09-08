using System.Collections.Generic;
using UnityEngine;

namespace BackgroundParallax
{
  public class ParallaxObserver : MonoBehaviour
  {
    [Header("Parallax observer")]
    [Header("PARALLAX LAYERS SETUP")]
    [SerializeField] private List<ParallaxLayer> _layers;


    public void ChangeSpeed(float speed)
    {
      
    }

    private void Update()
    {
      MoveSprites();
      if (!CheckIfNeedChangeSprite(out ParallaxLayer layer)) return;
      Debug.Log("Parallax sprite changed");
      layer.ChangeSprites();
    }

    private void MoveSprites()
    {
      foreach (ParallaxLayer layer in _layers)
        layer.Move();
    }

    private bool CheckIfNeedChangeSprite(out ParallaxLayer layer)
    {
      layer = null;
      foreach (ParallaxLayer l in _layers)
      {
        layer = l.CheckLayers();
        if (layer != null) break;
      }

      return layer != null;
    }
  }
}