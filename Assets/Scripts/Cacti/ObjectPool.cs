using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cacti
{
  public class ObjectPool : MonoBehaviour
  {
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private float _leftBorder = -10;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject[] prefab)
    {
      _camera = Camera.main;

      for (int i = 0; i < _capacity; i++)
      {
        int randomIndex = Random.Range(0, prefab.Length);
        GameObject spawned = Instantiate(prefab[randomIndex], _container.transform);
        spawned.SetActive(false);

        _pool.Add(spawned);
      }
    }

    protected bool TryGetObject(out GameObject result)
    {
      result = _pool.FirstOrDefault(p => p.activeSelf == false);

      return result != null;
    }

    protected void DisableObjectAbroadCamera()
    {
      foreach (var item in _pool)
      {
        if (!item.activeSelf) continue;

        if (item.transform.position.x < _leftBorder)
          item.SetActive(false);
      }
    }

    protected void SetActiveObjectsSpeed(float speed)
    {
      foreach (var item in _pool)
      {
        if (!item.activeSelf) continue;

        if (item.TryGetComponent(out CactusMover cactus))
          cactus.SetSpeed(speed);
      }
    }

    public void ResetPool()
    {
      foreach (var item in _pool)
        item.SetActive(false);
    }
  }
}